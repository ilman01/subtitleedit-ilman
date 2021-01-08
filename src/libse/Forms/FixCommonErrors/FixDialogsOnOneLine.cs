﻿using Nikse.SubtitleEdit.Core.Common;
using Nikse.SubtitleEdit.Core.Interfaces;

namespace Nikse.SubtitleEdit.Core.Forms.FixCommonErrors
{
    public class FixDialogsOnOneLine : IFixCommonError
    {
        public static class Language
        {
            public static string FixDialogsOnOneLine { get; set; } = "Fix dialogs on one line";
        }

        public void Fix(Subtitle subtitle, IFixCallbacks callbacks)
        {
            string fixAction = Language.FixDialogsOnOneLine;
            int noOfFixes = 0;
            for (int i = 0; i < subtitle.Paragraphs.Count; i++)
            {
                Paragraph p = subtitle.Paragraphs[i];
                string oldText = p.Text;
                var text = Helper.FixDialogsOnOneLine(oldText, callbacks.Language);
                if (oldText != text && callbacks.AllowFix(p, fixAction))
                {
                    p.Text = text;
                    noOfFixes++;
                    callbacks.AddFixToListView(p, fixAction, oldText, p.Text);
                }
            }
            callbacks.UpdateFixStatus(noOfFixes, Language.FixDialogsOnOneLine);
        }
    }
}