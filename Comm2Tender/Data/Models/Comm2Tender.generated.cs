//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/linq2db).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------

#pragma warning disable 1573, 1591

using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Mapping;

namespace Comm2Tender.Data
{
	/// <summary>
	/// Database       : Comm2Tender
	/// Data Source    : .\SQLEXPRESS
	/// Server Version : 16.00.1115
	/// </summary>
	public partial class Comm2TenderDB : LinqToDB.Data.DataConnection
	{
		public ITable<Agent>               Agent               { get { return this.GetTable<Agent>(); } }
		public ITable<CustomFeeDictionary> CustomFeeDictionary { get { return this.GetTable<CustomFeeDictionary>(); } }
		public ITable<PercentsDictionary>  PercentsDictionary  { get { return this.GetTable<PercentsDictionary>(); } }
		public ITable<Proposal>            Proposal            { get { return this.GetTable<Proposal>(); } }
		public ITable<Role>                Role                { get { return this.GetTable<Role>(); } }
		public ITable<Tender>              Tender              { get { return this.GetTable<Tender>(); } }
		public ITable<User>                User                { get { return this.GetTable<User>(); } }
		public ITable<UserToken>           UserToken           { get { return this.GetTable<UserToken>(); } }

		public Comm2TenderDB()
		{
			InitDataContext();
			InitMappingSchema();
		}

		public Comm2TenderDB(string configuration)
			: base(configuration)
		{
			InitDataContext();
			InitMappingSchema();
		}

		public Comm2TenderDB(DataOptions options)
			: base(options)
		{
			InitDataContext();
			InitMappingSchema();
		}

		public Comm2TenderDB(DataOptions<Comm2TenderDB> options)
			: base(options.Options)
		{
			InitDataContext();
			InitMappingSchema();
		}

		partial void InitDataContext  ();
		partial void InitMappingSchema();
	}

	[Table(Schema="dbo", Name="Agent")]
	public partial class Agent
	{
		[PrimaryKey, Identity] public int      AgentId                     { get; set; } // int
		[Column,     NotNull ] public DateTime AgentRegistrationDate       { get; set; } // datetime
		[Column,     NotNull ] public DateTime AgentSystemRegistrationDate { get; set; } // datetime
		[Column,     NotNull ] public decimal  OGRN                        { get; set; } // decimal(15, 0)
		[Column,     NotNull ] public decimal  INN                         { get; set; } // decimal(12, 0)
		[Column,     NotNull ] public decimal  KPP                         { get; set; } // decimal(9, 0)

		#region Associations

		/// <summary>
		/// FK_Proposal_ToAgent_BackReference (dbo.Proposal)
		/// </summary>
		[Association(ThisKey="AgentId", OtherKey="AgentId", CanBeNull=true)]
		public IEnumerable<Proposal> ProposalToAgents { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="CustomFeeDictionary")]
	public partial class CustomFeeDictionary
	{
		[PrimaryKey, Identity] public int     CustomFeeDictionaryId { get; set; } // int
		[Column,     NotNull ] public decimal MinAmount             { get; set; } // decimal(13, 3)
		[Column,     NotNull ] public decimal SummaryCustomFee      { get; set; } // decimal(11, 3)
	}

	[Table(Schema="dbo", Name="PercentsDictionary")]
	public partial class PercentsDictionary
	{
		[PrimaryKey, Identity] public int      PercentsDictionaryId { get; set; } // int
		[Column,     NotNull ] public DateTime DateEnter            { get; set; } // datetime
		/// <summary>
		/// ������ �� ��
		/// </summary>
		[Column,     NotNull ] public decimal  RefinancingRate      { get; set; } // decimal(4, 3)
		/// <summary>
		/// % ���
		/// </summary>
		[Column,     NotNull ] public decimal  Tmk                  { get; set; } // decimal(4, 3)
		/// <summary>
		/// ���������� ��������
		/// </summary>
		[Column,     NotNull ] public decimal  BankGuarantee        { get; set; } // decimal(4, 3)
		/// <summary>
		/// % �����������
		/// </summary>
		[Column,     NotNull ] public decimal  Credit               { get; set; } // decimal(4, 3)
		/// <summary>
		/// ���������� �������
		/// </summary>
		[Column,     NotNull ] public decimal  CustomDuty           { get; set; } // decimal(4, 3)
		/// <summary>
		/// ������ ���������������
		/// </summary>
		[Column,     NotNull ] public decimal  Discount             { get; set; } // decimal(4, 3)

		#region Associations

		/// <summary>
		/// FK_Tender_ToPercentsDictionary_BackReference (dbo.Tender)
		/// </summary>
		[Association(ThisKey="PercentsDictionaryId", OtherKey="PercentsDictionaryId", CanBeNull=true)]
		public IEnumerable<Tender> TenderToPercentsDictionaries { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Proposal")]
	public partial class Proposal
	{
		[PrimaryKey, Identity] public int     ProposalId             { get; set; } // int
		[Column,     NotNull ] public int     AgentId                { get; set; } // int
		[Column,     NotNull ] public int     UserId                 { get; set; } // int
		[Column,     NotNull ] public int     TenderId               { get; set; } // int
		/// <summary>
		/// ���������� ������(�����), ��
		/// </summary>
		[Column,     NotNull ] public int     CountPos               { get; set; } // int
		/// <summary>
		/// ��������� 1 �� ������(������)
		/// </summary>
		[Column,     NotNull ] public decimal PositionPrice          { get; set; } // decimal(8, 3)
		/// <summary>
		/// ��������� ��������, ���.
		/// </summary>
		[Column,     NotNull ] public decimal DeliveryCost           { get; set; } // decimal(8, 3)
		/// <summary>
		/// ����� ��������, ��
		/// </summary>
		[Column,     NotNull ] public int     DeliveryTime           { get; set; } // int
		/// <summary>
		/// ����� 1
		/// </summary>
		[Column,     NotNull ] public decimal PrepaidExpense1        { get; set; } // decimal(8, 3)
		/// <summary>
		/// ����� 2
		/// </summary>
		[Column,     NotNull ] public decimal PrepaidExpense2        { get; set; } // decimal(8, 3)
		/// <summary>
		/// ����� 3
		/// </summary>
		[Column,     NotNull ] public decimal PrepaidExpense3        { get; set; } // decimal(8, 3)
		/// <summary>
		/// ���� ������ 1, ��
		/// </summary>
		[Column,     NotNull ] public int     PeriodOfExecution1     { get; set; } // int
		/// <summary>
		/// ���� ������ 2, ��
		/// </summary>
		[Column,     NotNull ] public int     PeriodOfExecution2     { get; set; } // int
		/// <summary>
		/// ���� ������ 3, ��
		/// </summary>
		[Column,     NotNull ] public int     PeriodOfExecution3     { get; set; } // int
		/// <summary>
		/// ���������� 1, %
		/// </summary>
		[Column,     NotNull ] public decimal PostPaymant1           { get; set; } // decimal(8, 3)
		/// <summary>
		/// ���������� 2, %
		/// </summary>
		[Column,     NotNull ] public decimal PostPaymant2           { get; set; } // decimal(8, 3)
		/// <summary>
		/// ���������� 3, %
		/// </summary>
		[Column,     NotNull ] public decimal PostPaymant3           { get; set; } // decimal(8, 3)
		/// <summary>
		/// ���� ���������� 1, ��
		/// </summary>
		[Column,     NotNull ] public int     PostPaymantPeriod1     { get; set; } // int
		/// <summary>
		/// ���� ���������� 2, ��
		/// </summary>
		[Column,     NotNull ] public int     PostPaymantPeriod2     { get; set; } // int
		/// <summary>
		/// ���� ���������� 3, ��
		/// </summary>
		[Column,     NotNull ] public int     PostPaymantPeriod3     { get; set; } // int
		/// <summary>
		/// ����������
		/// </summary>
		[Column,     NotNull ] public bool    Accreditive            { get; set; } // bit
		/// <summary>
		/// ���������� ��������
		/// </summary>
		[Column,     NotNull ] public bool    BankGuarantee          { get; set; } // bit
		/// <summary>
		/// ���������� �������
		/// </summary>
		[Column,     NotNull ] public bool    CustomDuty             { get; set; } // bit
		/// <summary>
		/// ���������� ����
		/// </summary>
		[Column,     NotNull ] public bool    CustomFee              { get; set; } // bit
		/// <summary>
		/// ���� ��������� ������ ��������
		/// </summary>
		[Column,     NotNull ] public bool    MissingDeadlines       { get; set; } // bit
		/// <summary>
		/// ���� ��������� � �������� ������/������
		/// </summary>
		[Column,     NotNull ] public bool    PoorQuality            { get; set; } // bit
		/// <summary>
		/// ���� ��������� ���������� ����
		/// </summary>
		[Column,     NotNull ] public bool    NormsViolated          { get; set; } // bit
		/// <summary>
		/// ���� ������ � ����� �������
		/// </summary>
		[Column,     NotNull ] public bool    ExperienceCooperation  { get; set; } // bit
		/// <summary>
		/// ���� ������ �� �����
		/// </summary>
		[Column,     NotNull ] public bool    ExperienceMarket       { get; set; } // bit
		/// <summary>
		/// ������ � �������� ��������
		/// </summary>
		[Column,     NotNull ] public bool    Fines                  { get; set; } // bit
		/// <summary>
		/// ��������� ��� �������������. True - ���������, False - �������������.
		/// </summary>
		[Column,     NotNull ] public bool    Intermediary           { get; set; } // bit
		/// <summary>
		/// ������������ � ��������� ������
		/// </summary>
		[Column,     NotNull ] public bool    ProductionAndInventory { get; set; } // bit
		/// <summary>
		/// ������� ������������ ������������
		/// </summary>
		[Column,     NotNull ] public bool    ModernEquipment        { get; set; } // bit
		/// <summary>
		/// �������������� �������� � ���������
		/// </summary>
		[Column,     NotNull ] public bool    Georgraphy             { get; set; } // bit
		/// <summary>
		/// ���������� � ������ �������
		/// </summary>
		[Column,     NotNull ] public bool    Concessions            { get; set; } // bit
		/// <summary>
		/// ������� ����������
		/// </summary>
		[Column,     NotNull ] public bool    Complaints             { get; set; } // bit

		#region Associations

		/// <summary>
		/// FK_Proposal_ToAgent (dbo.Agent)
		/// </summary>
		[Association(ThisKey="AgentId", OtherKey="AgentId", CanBeNull=false)]
		public Agent Agent { get; set; }

		/// <summary>
		/// FK_Proposal_ToTender (dbo.Tender)
		/// </summary>
		[Association(ThisKey="TenderId", OtherKey="TenderId", CanBeNull=false)]
		public Tender Tender { get; set; }

		/// <summary>
		/// FK_Tender_ToProposal_BackReference (dbo.Tender)
		/// </summary>
		[Association(ThisKey="ProposalId", OtherKey="WinnerProposalId", CanBeNull=true)]
		public IEnumerable<Tender> TenderToProposals { get; set; }

		/// <summary>
		/// FK_Proposal_ToUser (dbo.User)
		/// </summary>
		[Association(ThisKey="UserId", OtherKey="UserId", CanBeNull=false)]
		public User User { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Role")]
	public partial class Role
	{
		[PrimaryKey, Identity] public int    RoleId { get; set; } // int
		[Column,     NotNull ] public string Name   { get; set; } // nvarchar(50)

		#region Associations

		/// <summary>
		/// FK_User_ToRole_BackReference (dbo.User)
		/// </summary>
		[Association(ThisKey="RoleId", OtherKey="RoleId", CanBeNull=true)]
		public IEnumerable<User> UserToRoles { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Tender")]
	public partial class Tender
	{
		[PrimaryKey, Identity   ] public int    TenderId             { get; set; } // int
		[Column,     NotNull    ] public string Number               { get; set; } // nvarchar(50)
		[Column,     NotNull    ] public string Discription          { get; set; } // nvarchar(50)
		[Column,     NotNull    ] public int    PercentsDictionaryId { get; set; } // int
		[Column,        Nullable] public int?   WinnerProposalId     { get; set; } // int

		#region Associations

		/// <summary>
		/// FK_Tender_ToPercentsDictionary (dbo.PercentsDictionary)
		/// </summary>
		[Association(ThisKey="PercentsDictionaryId", OtherKey="PercentsDictionaryId", CanBeNull=false)]
		public PercentsDictionary PercentsDictionary { get; set; }

		/// <summary>
		/// FK_Proposal_ToTender_BackReference (dbo.Proposal)
		/// </summary>
		[Association(ThisKey="TenderId", OtherKey="TenderId", CanBeNull=true)]
		public IEnumerable<Proposal> ProposalToTenders { get; set; }

		/// <summary>
		/// FK_Tender_ToProposal (dbo.Proposal)
		/// </summary>
		[Association(ThisKey="WinnerProposalId", OtherKey="ProposalId", CanBeNull=true)]
		public Proposal WinnerProposal { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="User")]
	public partial class User
	{
		[PrimaryKey, Identity] public int    UserId   { get; set; } // int
		[Column,     NotNull ] public int    RoleId   { get; set; } // int
		[Column,     NotNull ] public string Name     { get; set; } // nvarchar(50)
		[Column,     NotNull ] public string Email    { get; set; } // nvarchar(50)
		[Column,     NotNull ] public string Password { get; set; } // nvarchar(50)
		[Column,     NotNull ] public bool   IsActive { get; set; } // bit

		#region Associations

		/// <summary>
		/// FK_Proposal_ToUser_BackReference (dbo.Proposal)
		/// </summary>
		[Association(ThisKey="UserId", OtherKey="UserId", CanBeNull=true)]
		public IEnumerable<Proposal> ProposalToUsers { get; set; }

		/// <summary>
		/// FK_User_ToRole (dbo.Role)
		/// </summary>
		[Association(ThisKey="RoleId", OtherKey="RoleId", CanBeNull=false)]
		public Role Role { get; set; }

		/// <summary>
		/// FK_UserToken_ToUser_BackReference (dbo.UserToken)
		/// </summary>
		[Association(ThisKey="UserId", OtherKey="UserId", CanBeNull=true)]
		public IEnumerable<UserToken> UserTokenToUsers { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="UserToken")]
	public partial class UserToken
	{
		[PrimaryKey, Identity] public int      UserTokenId            { get; set; } // int
		[Column,     NotNull ] public int      UserId                 { get; set; } // int
		[Column,     NotNull ] public DateTime DateTime               { get; set; } // datetime
		[Column,     NotNull ] public string   Data                   { get; set; } // nvarchar(max)
		[Column,     NotNull ] public DateTime ExpiresAccessDateTime  { get; set; } // datetime
		[Column,     NotNull ] public DateTime ExpiresRefreshDateTime { get; set; } // datetime

		#region Associations

		/// <summary>
		/// FK_UserToken_ToUser (dbo.User)
		/// </summary>
		[Association(ThisKey="UserId", OtherKey="UserId", CanBeNull=false)]
		public User User { get; set; }

		#endregion
	}

	public static partial class TableExtensions
	{
		public static Agent Find(this ITable<Agent> table, int AgentId)
		{
			return table.FirstOrDefault(t =>
				t.AgentId == AgentId);
		}

		public static CustomFeeDictionary Find(this ITable<CustomFeeDictionary> table, int CustomFeeDictionaryId)
		{
			return table.FirstOrDefault(t =>
				t.CustomFeeDictionaryId == CustomFeeDictionaryId);
		}

		public static PercentsDictionary Find(this ITable<PercentsDictionary> table, int PercentsDictionaryId)
		{
			return table.FirstOrDefault(t =>
				t.PercentsDictionaryId == PercentsDictionaryId);
		}

		public static Proposal Find(this ITable<Proposal> table, int ProposalId)
		{
			return table.FirstOrDefault(t =>
				t.ProposalId == ProposalId);
		}

		public static Role Find(this ITable<Role> table, int RoleId)
		{
			return table.FirstOrDefault(t =>
				t.RoleId == RoleId);
		}

		public static Tender Find(this ITable<Tender> table, int TenderId)
		{
			return table.FirstOrDefault(t =>
				t.TenderId == TenderId);
		}

		public static User Find(this ITable<User> table, int UserId)
		{
			return table.FirstOrDefault(t =>
				t.UserId == UserId);
		}

		public static UserToken Find(this ITable<UserToken> table, int UserTokenId)
		{
			return table.FirstOrDefault(t =>
				t.UserTokenId == UserTokenId);
		}
	}
}

