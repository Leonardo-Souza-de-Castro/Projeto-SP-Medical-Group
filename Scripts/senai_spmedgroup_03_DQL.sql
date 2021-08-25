Use SP_Medical_Group;
Go

Select * From Clinica
Select * From Consulta
Select * From Status_Consulta
Select * From Medico
Select * From Tipo_Usuario
Select * From Pacientes
Select * From Especialidade

Select Count(Id_Prontuario)
From Pacientes;
Go

Select Convert(Varchar(10), Data_Nascimento, 3)
From Pacientes