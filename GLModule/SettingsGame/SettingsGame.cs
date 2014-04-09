using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.IO;
using GLModule.Constants;
using Microsoft.Win32;
using GLModule.PluginJS;

namespace GLModule.SettingsGame
{
    public static class Settings
    {
        [RegisterConfig]
        public static int GraphicAdapterIndex { get; set; }

        [RegisterConfig]
        public static int ResolutionIndex { get; set; }

        [RegisterConfig]
        public static int AntialiasingIndex { get; set; }

        [RegisterConfig]
        public static int AnisotropicFilteringIndex { get; set; }

        [RegisterConfig]
        public static int Music { get; set; }

        [RegisterConfig]
        public static int Sound { get; set; }

        [RegisterConfig]
        public static bool WindowMode { get; set; }

        [RegisterConfig]
        public static bool TopMost { get; set; }

        /// <summary>
        /// Aplicar as configurações realizadas pelo usuário ao jogo
        /// </summary>
        /// <param name="MessageErro">Caso o método retorne false, ele informa qual o motivo do erro</param>
        /// <returns>Informa se as configurações foram aplicadas com sucesso</returns>
        public static bool ApplyConfigs(out string MessageErro)
        {
            try
            {
                PropertyInfo[] propertys = SettingsGameConstants.TypeSettingsClass.GetProperties();
                Dictionary<string, string> ExternFile = new Dictionary<string, string>();
                for (int i = 0; i < propertys.Length; i++)
                {
                    foreach (object att in propertys[i].GetCustomAttributes(false))
                    {
                        if (att is ExternFileConfigAttribute)
                        {
                            ExternFileConfigAttribute EF = att as ExternFileConfigAttribute;
                            string Path = EF.Path.Length > 0 ? EF.Path : SettingsGameConstants.PathExternFile;
                            string SerializationBase;
                            if (!ExternFile.ContainsKey(Path))
                            {
                                SerializationBase = EF.ExternFileBaseSerialization.Length > 0 ? EF.ExternFileBaseSerialization : SettingsGameConstants.ExternFileBaseSerialization;
                                SerializationBase = SerializationBase.Replace("[" + propertys[i].Name + "]", propertys[i].GetValue(null, null).ToString());
                                ExternFile.Add(Path, SerializationBase);
                            }
                            else
                                ExternFile[Path] = ExternFile[Path].Replace("[" + propertys[i].Name + "]", propertys[i].GetValue(null, null).ToString());
                        }

                        else if (att is RegisterConfigAttribute)
                        {
                            RegisterConfigAttribute RC = att as RegisterConfigAttribute;
                            RegistryKey registry;
                            if (RC.Path != String.Empty)
                            {
                                registry = RC.RegistryLocal == TypeRegistryLocal.CurrentUser ?
                                                 Registry.CurrentUser.CreateSubKey(RC.Path) :
                                                 Registry.LocalMachine.CreateSubKey(RC.Path);
                            }
                            else
                                registry = SettingsGameConstants.PathRegistryKey;

                            registry.SetValue(propertys[i].Name, propertys[i].GetValue(null, null));
                        }

                        else if (att is ParamsConfigAttribute)
                        {
                            string Param = "[" + propertys[i].Name + "]";
                            if (SettingsGameConstants.ParamStartGame.IndexOf(Param) == -1)
                                throw new Exception("Atributo " + Param + " não encontrado nos parâmetros do Jogo");
                            SettingsGameConstants.ParamStartGame = SettingsGameConstants.ParamStartGame.Replace(Param, propertys[i].GetValue(null, null).ToString());
                        }
                        else
                            goto ContinueFor;
                    }
                ContinueFor:
                    continue;
                }

                if (ExternFile.Count > 0)
                    foreach (string Path in ExternFile.Keys)
                    {
                        if (File.Exists(Path)) { File.WriteAllText(Path, String.Empty); }
                        using (FileStream FS = File.Open(Path, FileMode.OpenOrCreate))
                            FS.Write(Encoding.ASCII.GetBytes(ExternFile[Path]), 0, ExternFile[Path].Length);
                    }

                MessageErro = String.Empty;
                InvokeFunctions.Invoke(FunctionsEnum.ApplyConfigs, MessageErro);
                return true;
            }
            catch (Exception ex)
            {
                MessageErro = ex.Message;
                InvokeFunctions.Invoke(FunctionsEnum.ApplyConfigs, MessageErro);
                return false;
            }
        }
    }
}
