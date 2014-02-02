using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GLModule.PluginJS;

namespace GLModule.Warnings.Hardware
{
    public class MemoryWarning : IWarning
    {
        public int GpuIndexArray { get; set; }
        public int CodeWarning { get; set; }
        public string Warning { get; set; }
        public string Recommendation { get; set; }
        public string MoreInformation { get; set; }
        public string ScriptRepair { get; set; }

        public void OpenMoreInformation()
        {
            if (MoreInformation != string.Empty)
                System.Diagnostics.Process.Start(MoreInformation);
            else
                Constants.ConsoleConstants.WriteInConsole(
                    "String de mais informações vazia\n" +
                    "Warning da Memória, Code: " + CodeWarning, System.Drawing.Color.DarkRed);
        }

        /// <summary>
        /// Tentar reparar o Warning com script recebido pelo servidor
        /// </summary>
        /// <param name="MsgErro">Caso a função retorne false, este argumento de saída estará informando o motivo</param>
        /// <returns>Caso a reparação seja um sucesso retornará true, senão retornará false</returns>
        public bool TryRepair(out string MsgErro)
        {
            if (ScriptRepair == String.Empty)
            {
                MsgErro = "Script para executar está vazio.";
                return false;
            }
            try
            {
                Engines.EngineSafePlugins.Execute(ScriptRepair);
                MsgErro = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                MsgErro = "Erro ao executar script para reparar Warning.\nWarning Memória Code: " + CodeWarning + "\nErro: " + ex.Message;
                return false;
            }
        }
    }
}
