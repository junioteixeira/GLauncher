using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using GLModule.Constants;
using Microsoft.Win32;

namespace GLModule.SettingsGame
{
    public static class Settings
    {
       // [AnotherPath(AnotherPathEnum.CurrrentUser, "Software\\GameGLauncher\\Settings\\Graphic")]
        public static int GraphicAdapterIndex { get; set; }

        [RegisterConfig]
        public static int ResolutionIndex { get; set; }


        public static int AntialiasingIndex { get; set; }


        public static int AnisotropicFilteringIndex { get; set; }


        public static int Music { get; set; }


        public static int Sound { get; set; }


        public static bool WindowMode { get; set; }

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
                for (int i = 0; i < propertys.Length; i++)
                {
                    foreach (object att in propertys[i].GetCustomAttributes(false))
                    {
                        if (att is NonConfigAttribute)
                            goto ContinueFor;
                        else if (att is ExternFileConfigAttribute)
                        {
                           ExternFileConfigAttribute externFile = att as ExternFileConfigAttribute;
                       
                        }
                    }
                ContinueFor:
                    continue;
                }
                MessageErro = String.Empty;
                return true;
            }
            catch (Exception ex)
            {
                MessageErro = ex.Message;
                return false;
            }
        }
    }
}
