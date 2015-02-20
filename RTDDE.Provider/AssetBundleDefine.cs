using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTDDE.Provider
{
    public static class AssetBundleDefine
    {
        private const string mc_RootDirPath = "http://www.acquirespdl.jp/RTD/DLC/";

        private static readonly string[] VersionDir = new string[]
        {
            "V9999",
            "V1011",
            "V1012",
            "V1013",
            "V1014",
            "V1015",
            "V1016",
            "V1017",
            "V1018",
            "V1019",
            "V1020c7R7HlupcYzJ80UutCh3B4HQc9MEHUvf",
            "V1021ppHGecITa3lWMw3sxNnrP2hol0mIHZXh",
            "V1022KiPPeA9HOywINI2Hn66Z0fz6XFyhEuza",
            "V1023SqWsel5obmweh9emcO2T5d1zpOjqpNwL",
            "V1024Jh5PuJFeFh9d8yjdaWAojOmHeu4RiiAU",
            "V1025rwXdTTdoREfgwYTBTzCBbm5TpRa9xok5",
            "V1026ZP1oCCIBL8Vu8Hy72rEqUmz6yH89Fq83",
            "V1027pfH3RRYQaOl9OWDMH6U5j1ELEWNOU6NI",
            "V1028iHJx4Umb7ns20EtNB3Qh797yHlsTNOCH",
            "V1029ToRU8oDwA3FdtTX9wFKxxEyVbb4UnlnO",
            "V1030A0ui3BCFdpgig2INGDBOSOgtNvJHLQBj",
            "V1031wlkc1YB6cB0nGXtglkmixajjhA0u5sT9",
            "V1032sMM2ZMTiBjnepB4AscIUifaolEIbhUJ4",
            "V1033eKyylg87Ot0izVivIMeq6uGYCyJObZ3T"
        };
        public static string GetVersionDirectory(int folderId)
        {
            return AssetBundleDefine.VersionDir[folderId];
        }
        public struct AssetBundleInfo
        {
            private int m_Folder;
            private string m_FileName;
            private int m_Version;

            public string fileName
            {
                get
                {
                    return this.m_FileName;
                }
            }

            public int folder
            {
                get
                {
                    return this.m_Folder;
                }
            }

            public AssetBundleInfo(int folderId, string fileName, int version = 0)
            {
                this.m_Folder = folderId;
                this.m_FileName = fileName;
                this.m_Version = version;
            }

            public string GetURL()
            {
                string versionDirectory = AssetBundleDefine.GetVersionDirectory(this.m_Folder);
                return string.Concat(mc_RootDirPath, "Android/", versionDirectory, "/", this.m_FileName, ".unity3d");
            }

            public int GetVersion()
            {
                return this.m_Version;
            }
        }
    }
}