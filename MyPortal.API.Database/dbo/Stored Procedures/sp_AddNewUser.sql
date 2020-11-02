
CREATE PROCEDURE [dbo].[sp_AddNewUser] (@Username Nvarchar(30)
	,@PasswordHash Nvarchar(30)
	,@PasswordSalt Nvarchar(30)
	,@Firstname Nvarchar(30)
	,@LastName Nvarchar(30)
	,@Age Nvarchar(30)
	,@Sex Nvarchar(30)
	,@Race Nvarchar(30)
	,@Designation Nvarchar(30)
	,@JobTitle Nvarchar(30)
	,@SalaryLevel int
	,@ChiefDirectorate Nvarchar(30)
	,@Directorate Nvarchar(30)
	,@SubDirectorate Nvarchar(30)
	,@OfficeLocation Nvarchar(30)
	,@ContactNumberOffice Nvarchar(30)
	,@ContactCell Nvarchar(30)
	,@AppointmentDate Nvarchar(30)
	,@ProbationPeriodstatus Nvarchar(30)
	,@InductionStatus Nvarchar(30)
	,@Manager Nvarchar(30)
	,@Highestqualification Nvarchar(30)
	,@HomeAddress Nvarchar(30)
	,@Maritalstatus Nvarchar(30)
	,@SpouseName Nvarchar(30)
	,@SpouseMaidenName Nvarchar(30)
	,@NextofKinName Nvarchar(30)
	,@NextofKinSurname Nvarchar(30)
	,@NextofKinRelation Nvarchar(30)
	,@Password Nvarchar(30)
	)
AS
	INSERT INTO Users([Username]
      ,[PasswordHash]
      ,[PasswordSalt]
      ,[Firstname]
      ,[LastName]
      ,[Age]
      ,[Sex]
      ,[Race]
      ,[Designation]
      ,[JobTitle]
      ,[SalaryLevel]
      ,[ChiefDirectorate]
      ,[Directorate]
      ,[SubDirectorate]
      ,[OfficeLocation]
      ,[ContactNumberOffice]
      ,[ContactCell]
      ,[AppointmentDate]
      ,[ProbationPeriodstatus]
      ,[InductionStatus]
      ,[Manager]
      ,[Highestqualification]
      ,[HomeAddress]
      ,[Maritalstatus]
      ,[SpouseName]
      ,[SpouseMaidenName]
      ,[NextofKinName]
      ,[NextofKinSurname]
      ,[NextofKinRelation]
      ,[Password]
	  )
  VALUES (
	@Username 
	,@PasswordHash 
	,@PasswordSalt 
	,@Firstname 
	,@LastName 
	,@Age 
	,@Sex 
	,@Race 
	,@Designation 
	,@JobTitle 
	,@SalaryLevel 
	,@ChiefDirectorate 
	,@Directorate 
	,@SubDirectorate 
	,@OfficeLocation 
	,@ContactNumberOffice 
	,@ContactCell 
	,@AppointmentDate 
	,@ProbationPeriodstatus 
	,@InductionStatus 
	,@Manager 
	,@Highestqualification 
	,@HomeAddress 
	,@Maritalstatus 
	,@SpouseName 
	,@SpouseMaidenName 
	,@NextofKinName 
	,@NextofKinSurname 
	,@NextofKinRelation 
	,@Password 
	)