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

Select Convert(Varchar(10), Data_Nascimento, 103)
From Pacientes

Select Datediff(Year, Data_Nascimento, Getdate()) 
From Pacientes;
Go

Create Function MedicoEspecialidade(@IdEspecialidade int)-- Função para calcular quantos médicos tem em cada especialide
Returns Int
As
Begin
	Declare @Quantidade int
	Set @Quantidade =(Select Count(@IdEspecialidade) From Medico Where Id_Especialidade = @IdEspecialidade)
	Return @Quantidade
End
Go

Select dbo.MedicoEspecialidade(16);
Go

Create Procedure Busca_Usuario -- Procedure que retorna o nome do paciente a data de nascimento e a idade
@Nome_Usuario Varchar (50)
As
	Select Id_Prontuario, Nome, Convert(Varchar(10), Data_Nascimento, 103) As 'Data de Nascimento', Datediff(Year, Data_Nascimento, Getdate()) As 'Idade'
	From Pacientes
	Where Nome = @Nome_Usuario

Execute Busca_Usuario 'Henrique'