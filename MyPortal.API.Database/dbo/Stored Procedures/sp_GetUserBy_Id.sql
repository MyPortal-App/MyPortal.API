

CREATE PROCEDURE [dbo].[sp_GetUserBy_Id] @id int
AS
	SELECT
		Id
		,Username
		,PasswordHash
		,PasswordSalt
		,Firstname
		,LastName
		,Age
		,Sex
		,Race
		,Designation
		,JobTitle
		,SalaryLevel
		,ChiefDirectorate
		,Directorate
		,SubDirectorate
		,OfficeLocation
		,ContactNumberOffice
		,ContactCell
		,AppointmentDate
		,ProbationPeriodstatus
		,InductionStatus
		,Manager
		,Highestqualification
		,HomeAddress
		,Maritalstatus
		,SpouseName
		,SpouseMaidenName
		,NextofKinName
		,NextofKinSurname
		,NextofKinRelation
		,[Password]
	FROM
		Users
	where id = @id