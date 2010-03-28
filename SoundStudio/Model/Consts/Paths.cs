using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundStudio.Model.Consts
{
    public static class Paths
    {
        public struct Drum {
            public const string Name = @"drum";
            public const string Sound = @"\Model\Sounds\drum.wav";
            public const string Icon = @"\View\Images\drum.gif";
        }
        public struct Frog
        {
            public const string Name = @"frog";
            public const string Sound = @"\Model\Sounds\frog.wav";
            public const string Icon = @"\View\Images\frog.gif";
        }
        public struct Horn
        {
            public const string Name = @"horn";
            public const string Sound = @"\Model\Sounds\horn.wav";
            public const string Icon = @"\View\Images\horn.gif";
        }
        public struct Pointer {
            public const string Path = @"\View\Images\pointer.gif";
        }

        public static string CombinePath(string givenPath) {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Environment.CurrentDirectory);
            string localPath = String.Concat(di.Parent.Parent.FullName, givenPath);
            return localPath;
        }
    }
}
