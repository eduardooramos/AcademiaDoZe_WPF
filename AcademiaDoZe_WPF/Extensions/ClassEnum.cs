﻿using System.ComponentModel;
using System.Reflection;

namespace AcademiaDoZe_WPF.Extensions;

public enum PlanoMatriculaEnum
{
    [Description("Mensal")]
    Mensal = '1',
    [Description("Trimestral")]
    Trimestral = '2',
    [Description("Semestral")]
    Semestral = '3',
    [Description("Anual")]
    Anual = '4'
}

public enum RestricaoMedicaEnum
{
    [Description("Nenhum")]
    Nenhum = '1',
    [Description("Problemas Cardíacos")]
    ProblemasCardiacos = '2',
    [Description("Problemas Respiratórios")]
    ProblemasRespiratorios = '3',
    [Description("Lesões Musculares")]
    LesoesMusculares = '4',
    [Description("Pressão Alta")]
    PressaoAlta = '5',
    [Description("Diabetes")]
    Diabetes = '6',
    [Description("Gravidez")]
    Gravidez = '7',
    [Description("Labirinto")]
    Labirinto = '8',
    [Description("Alergias")]
    Alergias = '9',
    [Description("Remédios Uso Contínuo")]
    RemediosUsoContinuo = 'A',
    [Description("Outras")]
    Outras = 'B'
}

public enum ColaboradorTipoEnum
{
    [Description("Administrador")]
    Administrador = '1',
    [Description("Atendente")]
    Atendente = '2',
    [Description("Instrutor")]
    Instrutor = '3',
}

public enum ColaboradorVinculoEnum
{
    [Description("CLT")]
    Clt = '1',
    [Description("Estágio")]
    Estágio = '2',
}

public static class EnumExtensions
{
    public static string GetDescription(this Enum GenericEnum)
    {
        Type genericEnumType = GenericEnum.GetType();
        MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            var _Attribs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (_Attribs != null && _Attribs.Count() > 0)
            {
                return ((DescriptionAttribute)_Attribs.ElementAt(0)).Description;
            }
        }
        return GenericEnum.ToString();
    }
}