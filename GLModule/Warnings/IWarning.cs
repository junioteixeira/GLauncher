using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLModule.Warnings
{
    public interface IWarning
    {
        /// <summary>
        /// Código do aviso
        /// </summary>
        int CodeWarning { get; set; }

        /// <summary>
        /// Mensagem do aviso
        /// </summary>
        string Warning { get; set; }

        /// <summary>
        /// Recomendação a se fazer para repará-lo
        /// </summary>
        string Recommendation { get; set; }

        /// <summary>
        /// URL ou algo que contenha mais informações para o usuário
        /// </summary>
        string MoreInformation { get; set; }

        /// <summary>
        /// Script para reparar o aviso
        /// </summary>
        string ScriptRepair { get; set; }

        /// <summary>
        /// Abrir mais informações
        /// </summary>
        void OpenMoreInformation();

        /// <summary>
        /// Tentar reparar com base no script recebido
        /// </summary>
        /// <param name="MsgErro">Mensagem de erro ao tentar reparar</param>
        /// <returns>Informa se a reparação ocorreu com sucesso</returns>
        bool TryRepair(out string MsgErro);
    }
}
