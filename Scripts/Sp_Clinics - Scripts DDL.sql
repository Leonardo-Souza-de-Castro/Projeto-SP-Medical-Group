Create Database SP_Medical_Group;
Go

Use SP_Medical_Group;
Go

Create Table Tipo_Usuario(
Id_Tipo Int Primary Key Identity,
Nome_Tipo Varchar(20)
);
Go

Create Table Clinica(
Id_Clinica Int Primary Key Identity,
Endereco Varchar(300) Not Null,
Hora_Abertura time Not Null,
Hora_Fechamento time Not Null,
Cnpj Varchar(20) Not Null Unique,
Nome_Fantasia Varchar(50) Not Null,
Razao_Social Varchar(70) Not Null Unique
);
Go

Create Table Especialidade(
Id_Especialidade Int Primary Key Identity,
Nome_Especialidade Varchar(200) Not Null Unique,
);
Go

Create Table Status_Consulta(
Id_Status Int Primary Key Identity,
Descricao Varchar(12) Not Null
);
Go

Create Table Pacientes(
Id_Prontuario Int Primary Key Identity,
Id_Tipo Int Foreign Key References Tipo_Usuario(Id_Tipo),
Nome Varchar(500) Not Null,
Rg Char(13) Not Null,
Cpf Char(11) Not Null Unique,
Data_Nascimento Date Not Null,
Telefone Varchar(15),
Endereco Varchar(300)
);
Go

Create Table Medico(
Id_Medico Int Primary Key Identity,
Id_Especialidade Int Foreign Key References Especialidade (Id_Especialidade),
Id_Tipo Int Foreign Key References Tipo_Usuario(Id_Tipo),
Id_Clinica Int Foreign Key References Clinica(Id_Clinica),
Nome Varchar(150) Not Null,
Crm Varchar(15) Not Null Unique,
Email Varchar(200) Not Null
);
Go

Create Table Consulta(
Id_Consulta Int Primary Key Identity,
Id_Prontuario Int Foreign Key References Pacientes (Id_Prontuario),
Id_Medico Int Foreign Key References Medico (Id_Medico),
Id_Status Int Foreign Key References Status_Consulta (Id_Status),
Id_Clinica Int Foreign Key References Clinica (Id_Clinica),
Data_Consulta Date Not Null 
);
Go
