using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace RedJ_Code
{
    public partial class TerminalForm : Form
    {
        private static readonly TextStyle OutputStyle = new(Brushes.LightGray, null, FontStyle.Regular);
        private static readonly TextStyle ErrorStyle = new(Brushes.Red, null, FontStyle.Regular);

        private readonly FastColoredTextBox textbox;
        private readonly Process cmd;
        private readonly Encoding encoding;
        private readonly char[] outputBuffer = new char[1024];
        private readonly char[] errorBuffer = new char[1024];
        private readonly string[] history = new string[16];
        private string input = string.Empty;
        private int currentPos = -1;

        public TerminalForm()
        {
            InitializeComponent();

            #region Init Console Textbox

            textbox = new FastColoredTextBox()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Black,
                ForeColor = Color.White,
                SelectionColor = Color.White,
                ShowLineNumbers = false,
                ShowScrollBars = true,
                WordWrap = true,
                WordWrapMode = WordWrapMode.CharWrapControlWidth,
                WordWrapAutoIndent = false,
                AutoIndent = false,
                AutoIndentChars = false,
                AutoCompleteBrackets = false,
                WideCaret = true,
                Font = Font,
                Hotkeys = StringTable.TerminalFastColoredTextBoxHotkeys
            };

            textbox.KeyPressing += KeyPressing;
            textbox.KeyPressed += KeyPressed;
            textbox.PreviewKeyDown += Textbox_PreviewKeyDown;
            textbox.Pasting += Textbox_Pasting;

            Controls.Add(textbox);

            #endregion

            #region Init CMD Process

            encoding = Encoding.Default;

            cmd = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "CMD.EXE",
                    Arguments = string.Empty,
                    WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    StandardInputEncoding = encoding,
                    StandardOutputEncoding = encoding,
                    StandardErrorEncoding = encoding
                },
                EnableRaisingEvents = true
            };

            cmd.Exited += Exited;
            //cmd.OutputDataReceived += OutputDataReceived;
            //cmd.ErrorDataReceived += ErrorDataReceived;

            cmd.Start();
            //cmd.BeginOutputReadLine();
            //cmd.BeginErrorReadLine();

            //StartOutputReadAsync();
            //StartErrorReadAsync();

            ReadOutputStreamAsync();
            ReadErrorStreamAsync();

            #endregion
        }

        #region Console Events

        private void KeyPressing(object? sender, KeyPressEventArgs e)
        {
            textbox.GoEnd();
        }
        
        private void KeyPressed(object? sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '\r':
                    textbox.Range.ReadOnly = true;
                    cmd.StandardInput.WriteLine(input);
                    AddToHistory(input);
                    input = string.Empty;
                    break;
                case '\b':
                    if (!string.IsNullOrEmpty(input))
                        input = input.Remove(input.Length - 1, 1);
                    break;
                default:
                    input += e.KeyChar;
                    break;
            }
        }

        private void Textbox_PreviewKeyDown(object? sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.C) && textbox.Selection.IsEmpty)
            {
                e.IsInputKey = false;
                KillChildProcess();
                return;
            }
            
            switch (e.KeyValue)
            {
                case 0x1B:
                    SetInput(string.Empty);
                    break;
                case 0x26:
                    SetInput(GetNextHistory());
                    break;
                case 0x28:
                    SetInput(GetPrevHistory());
                    break;
                case 0x25:
                case 0x27:
                    e.IsInputKey = false;
                    break;
            }
        }

        private void Textbox_Pasting(object? sender, TextChangingEventArgs e)
        {
            input += e.InsertingText;
        }

        #endregion

        #region Console Methods

        private void Write(string text, Style style)
        {
            if (text.Length == 0 || text[0] == '\r' || Handle == IntPtr.Zero) return;
            textbox.Invoke(() =>
            {
                textbox.AppendText(text, style);
                textbox.Range.ReadOnly = true;
                textbox.GoEnd();
            });
        }

        private void WriteLine(string text, Style style)
        {
            Write(text + Environment.NewLine, style);
        }

        private void AddToHistory(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                return;
            }
            for (int i = history.Length - 1; i > 0; i--)
            {
                history[i] = history[i - 1];
            }
            history[0] = command;
            currentPos = -1;
        }

        private string GetNextHistory()
        {
            if (currentPos + 1 < history.Length && !string.IsNullOrEmpty(history[currentPos + 1]))
            {
                currentPos ++;
            }
            return history[currentPos];
        }

        private string GetPrevHistory()
        {
            if (currentPos - 1 > -1)
            {
                currentPos --;
            }
            else if (currentPos < 0)
            {
                currentPos = 0;
            }
            return history[currentPos];
        }

        private void SetInput(string s)
        {
            textbox.GoEnd();
            for (int i = 0; i < input.Length; i++)
            {
                textbox.Selection.GoLeft(true);
            }
            textbox.SelectedText = input = s;
        }

        #endregion

        #region Process Events

        private void Exited(object? sender, EventArgs e)
        {
            Close();
        }

        private void OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                WriteLine(e.Data, OutputStyle);
            }
        }

        private void ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                WriteLine(e.Data, ErrorStyle);
            }
        }

        #endregion

        #region Process Methods

        private void ReadOutputStreamAsync()
        {
            //while (true)
            //{
            //    string? ln = cmd.StandardOutput.ReadLine();
            //    if (string.IsNullOrEmpty(ln)) break;
            //    else WriteLine(ln, OutputStyle);
            //}

            Task.Run(async () =>
            {
                while (!cmd.StandardOutput.EndOfStream)
                {
                    int bytesRead = await cmd.StandardOutput.ReadAsync(outputBuffer, 0, outputBuffer.Length);
                    if (bytesRead > 0)
                    {
                        string output = new string(outputBuffer, 0, bytesRead);
                        Write(output, OutputStyle);
                    }
                }
            });
        }

        private void ReadErrorStreamAsync()
        {
            Task.Run(async () =>
            {
                cmd.StandardInput.WriteLine();

                _ = await cmd.StandardError.ReadAsync(errorBuffer, 0, errorBuffer.Length);

                while (!cmd.StandardError.EndOfStream)
                {
                    int bytesRead = await cmd.StandardError.ReadAsync(errorBuffer, 0, errorBuffer.Length);
                    if (bytesRead > 0)
                    {
                        string error = new string(errorBuffer, 0, bytesRead);
                        Write(error, ErrorStyle);
                    }
                }
            });
        }

        private async void StartOutputReadAsync()
        {
            //await Task.Run(() =>
            //{
            //    cmd.StandardOutput.ReadBlockAsync(outputBuffer, 0, outputBuffer.Length).GetAwaiter().OnCompleted(() =>
            //    {
            //        Write(new string(outputBuffer), OutputStyle);
            //        StartOutputReadAsync();
            //    });
            //});

            //await Task.Run(() =>
            //{
            //    var read = cmd.StandardOutput.ReadAsync(outputBuffer, 0, outputBuffer.Length);

            //    read.GetAwaiter().OnCompleted(() =>
            //    {
            //        if (read.Result > 0)
            //        {
            //            string output = new string(outputBuffer).TrimEnd('\0');
            //            Write(output, OutputStyle);
            //        }
            //        StartOutputReadAsync();
            //    });
            //});

            //while (!cmd.StandardOutput.EndOfStream)
            //{
            //    int bytesRead = await cmd.StandardOutput.ReadAsync(outputBuffer, 0, outputBuffer.Length);
            //    if (bytesRead > 0)
            //    {
            //        string output = new string(outputBuffer, 0, bytesRead);
            //        Write(output, OutputStyle);
            //    }
            //}

            //await Task.Run(async () =>
            //{
            //    int bytesWritten = await cmd.StandardOutput.ReadBlockAsync(outputBuffer, 0, errorBuffer.Length);
            //    if (bytesWritten > 0)
            //    {
            //        Write(new string(outputBuffer), OutputStyle);
            //    }
            //    StartOutputReadAsync();
            //});
        }

        private async void StartErrorReadAsync()
        {
            //await Task.Run(() =>
            //{
            //    var read = cmd.StandardError.ReadAsync(errorBuffer, 0, errorBuffer.Length);

            //    read.GetAwaiter().OnCompleted(() =>
            //    {
            //        if (read.Result > 0)
            //        {
            //            string error = new string(errorBuffer).TrimEnd('\0');
            //            Write(error, ErrorStyle);
            //        }
            //        StartErrorReadAsync();
            //    });
            //});

            //await Task.Run(() =>
            //{
            //    cmd.StandardError.ReadBlockAsync(errorBuffer, 0, errorBuffer.Length).GetAwaiter().OnCompleted(() =>
            //    {
            //        Write(new string(errorBuffer), ErrorStyle);
            //        StartErrorReadAsync();
            //    });
            //});

            //while (!cmd.StandardError.EndOfStream)
            //{
            //    int bytesRead = await cmd.StandardError.ReadAsync(errorBuffer, 0, errorBuffer.Length);
            //    if (bytesRead > 0)
            //    {
            //        string error = new string(errorBuffer, 0, bytesRead);
            //        Write(error, ErrorStyle);
            //    }
            //}
        }

        //private string GetDecodedString(char[] chars)
        //{
        //    byte[] bytes = new byte[chars.Length];
        //    Convert.From
        //}

        private void KillChildProcess()
        {
            cmd.KillSubprocesses();
        }

        #endregion

        #region Form Events

        private void TerminalForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            cmd.Kill(true);
        }

        #endregion
    }
}
