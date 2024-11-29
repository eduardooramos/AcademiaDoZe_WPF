﻿using AcademiaDoZe_WPF.Extensions;

namespace AcademiaDoZe_WPF.Model;

public class Matricula
{
    public int Id { get; set; }
    public int AlunoId { get; set; }
    public int ColaboradorId { get; set; }
    public PlanoMatriculaEnum Plano { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public RestricaoMedicaEnum RestricaoMedica { get; set; }
    public string ObsRestricao { get; set; }
    public string Objetivo { get; set; }
    public byte[] LaudoMedico { get; set; }
    public Matricula()
    {
        DataInicio = DateTime.Now;
        DataFim = DateTime.Now;
    }
}
