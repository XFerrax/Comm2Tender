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
	/// Data Source    : tcp://nanopi.ferraxnet:3343
	/// Server Version : 16.3 (Debian 16.3-1.pgdg120+1)
	/// </summary>
	public partial class Comm2TenderDB : LinqToDB.Data.DataConnection
	{
		public ITable<Agent>               Agent               { get { return this.GetTable<Agent>(); } }
		public ITable<CustomFeeDictionary> CustomFeeDictionary { get { return this.GetTable<CustomFeeDictionary>(); } }
		/// <summary>
		/// ������ �� ��
		/// </summary>
		public ITable<PercentsDictionary>  PercentsDictionary  { get { return this.GetTable<PercentsDictionary>(); } }
		/// <summary>
		/// ���������� ������(�����), ��
		/// </summary>
		public ITable<Proposal>            Proposal            { get { return this.GetTable<Proposal>(); } }
		public ITable<Role>                Role                { get { return this.GetTable<Role>(); } }
		public ITable<Tender>              Tender              { get { return this.GetTable<Tender>(); } }
		public ITable<User>                User                { get { return this.GetTable<User>(); } }
		public ITable<UserToken>           UserToken           { get { return this.GetTable<UserToken>(); } }

		partial void InitMappingSchema()
		{
		}

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
		[PrimaryKey, Identity] public long     AgentId                     { get; set; } // bigint
		[Column,     NotNull ] public string   Name                        { get; set; } // text
		[Column,     NotNull ] public DateTime AgentRegistrationDate       { get; set; } // date
		[Column,     NotNull ] public DateTime AgentSystemRegistrationDate { get; set; } // date
		[Column,     NotNull ] public decimal  OGRN                        { get; set; } // numeric
		[Column,     NotNull ] public decimal  INN                         { get; set; } // numeric
		[Column,     NotNull ] public decimal  KPP                         { get; set; } // numeric

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
		[PrimaryKey, Identity] public long    CustomFeeDictionaryId { get; set; } // bigint
		[Column,     NotNull ] public decimal MinAmount             { get; set; } // numeric
		[Column,     NotNull ] public decimal SummaryCustomFee      { get; set; } // numeric
	}

	/// <summary>
	/// ������ �� ��
	/// </summary>
	[Table(Schema="dbo", Name="PercentsDictionary")]
	public partial class PercentsDictionary
	{
		[PrimaryKey, Identity] public long     PercentsDictionaryId { get; set; } // bigint
		[Column,     NotNull ] public DateTime DateEnter            { get; set; } // date
		/// <summary>
		/// ������ �� ��
		/// </summary>
		[Column,     NotNull ] public decimal  RefinancingRate      { get; set; } // numeric
		/// <summary>
		/// % ���
		/// </summary>
		[Column,     NotNull ] public decimal  Tmk                  { get; set; } // numeric
		/// <summary>
		/// ���������� ��������
		/// </summary>
		[Column,     NotNull ] public decimal  BankGuarantee        { get; set; } // numeric
		/// <summary>
		/// % �����������
		/// </summary>
		[Column,     NotNull ] public decimal  Credit               { get; set; } // numeric
		/// <summary>
		/// ���������� �������
		/// </summary>
		[Column,     NotNull ] public decimal  CustomDuty           { get; set; } // numeric
		/// <summary>
		/// ������ ���������������
		/// </summary>
		[Column,     NotNull ] public decimal  Discount             { get; set; } // numeric

		#region Associations

		/// <summary>
		/// FK_Tender_ToPercentsDictionary_BackReference (dbo.Tender)
		/// </summary>
		[Association(ThisKey="PercentsDictionaryId", OtherKey="PercentsDictionaryId", CanBeNull=true)]
		public IEnumerable<Tender> TenderToPercentsDictionaries { get; set; }

		#endregion
	}

	/// <summary>
	/// ���������� ������(�����), ��
	/// </summary>
	[Table(Schema="dbo", Name="Proposal")]
	public partial class Proposal
	{
		[PrimaryKey, Identity] public long    ProposalId             { get; set; } // bigint
		[Column,     NotNull ] public long    AgentId                { get; set; } // bigint
		[Column,     NotNull ] public long    UserId                 { get; set; } // bigint
		[Column,     NotNull ] public long    TenderId               { get; set; } // bigint
		/// <summary>
		/// ���������� ������(�����), ��
		/// </summary>
		[Column,     NotNull ] public decimal CountPos               { get; set; } // numeric
		/// <summary>
		/// ��������� 1 �� ������(������)
		/// </summary>
		[Column,     NotNull ] public decimal PositionPrice          { get; set; } // numeric
		/// <summary>
		/// ��������� ��������, ���.
		/// </summary>
		[Column,     NotNull ] public decimal DeliveryCost           { get; set; } // numeric
		/// <summary>
		/// ����� ��������, ��
		/// </summary>
		[Column,     NotNull ] public decimal DeliveryTime           { get; set; } // numeric
		/// <summary>
		/// ����� 1
		/// </summary>
		[Column,     NotNull ] public decimal PrepaidExpense1        { get; set; } // numeric
		/// <summary>
		/// ����� 2
		/// </summary>
		[Column,     NotNull ] public decimal PrepaidExpense2        { get; set; } // numeric
		/// <summary>
		/// ����� 3
		/// </summary>
		[Column,     NotNull ] public decimal PrepaidExpense3        { get; set; } // numeric
		/// <summary>
		/// ���� ������ 1, ��
		/// </summary>
		[Column,     NotNull ] public decimal PeriodOfExecution1     { get; set; } // numeric
		/// <summary>
		/// ���� ������ 2, ��
		/// </summary>
		[Column,     NotNull ] public decimal PeriodOfExecution2     { get; set; } // numeric
		/// <summary>
		/// ���� ������ 3, ��
		/// </summary>
		[Column,     NotNull ] public decimal PeriodOfExecution3     { get; set; } // numeric
		/// <summary>
		/// ���������� 1, %
		/// </summary>
		[Column,     NotNull ] public decimal PostPaymant1           { get; set; } // numeric
		/// <summary>
		/// ���������� 2, %
		/// </summary>
		[Column,     NotNull ] public decimal PostPaymant2           { get; set; } // numeric
		/// <summary>
		/// ���������� 3, %
		/// </summary>
		[Column,     NotNull ] public decimal PostPaymant3           { get; set; } // numeric
		/// <summary>
		/// ���� ���������� 1, ��
		/// </summary>
		[Column,     NotNull ] public decimal PostPaymantPeriod1     { get; set; } // numeric
		/// <summary>
		/// ���� ���������� 2, ��
		/// </summary>
		[Column,     NotNull ] public decimal PostPaymantPeriod2     { get; set; } // numeric
		/// <summary>
		/// ���� ���������� 3, ��
		/// </summary>
		[Column,     NotNull ] public decimal PostPaymantPeriod3     { get; set; } // numeric
		[Column,     NotNull ] public bool    Accreditive            { get; set; } // boolean
		[Column,     NotNull ] public bool    BankGuarantee          { get; set; } // boolean
		[Column,     NotNull ] public bool    CustomDuty             { get; set; } // boolean
		[Column,     NotNull ] public bool    CustomFee              { get; set; } // boolean
		[Column,     NotNull ] public bool    MissingDeadlines       { get; set; } // boolean
		[Column,     NotNull ] public bool    PoorQuality            { get; set; } // boolean
		[Column,     NotNull ] public bool    NormsViolated          { get; set; } // boolean
		[Column,     NotNull ] public bool    ExperienceCooperation  { get; set; } // boolean
		[Column,     NotNull ] public bool    ExperienceMarket       { get; set; } // boolean
		[Column,     NotNull ] public bool    Fines                  { get; set; } // boolean
		[Column,     NotNull ] public bool    Intermediary           { get; set; } // boolean
		[Column,     NotNull ] public bool    ProductionAndInventory { get; set; } // boolean
		[Column,     NotNull ] public bool    ModernEquipment        { get; set; } // boolean
		[Column,     NotNull ] public bool    Georgraphy             { get; set; } // boolean
		[Column,     NotNull ] public bool    Concessions            { get; set; } // boolean
		[Column,     NotNull ] public bool    Complaints             { get; set; } // boolean

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
		[PrimaryKey, Identity] public long   RoleId { get; set; } // bigint
		[Column,     NotNull ] public string Name   { get; set; } // text

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
		[PrimaryKey, Identity   ] public long   TenderId             { get; set; } // bigint
		[Column,     NotNull    ] public string Number               { get; set; } // text
		[Column,     NotNull    ] public string Discription          { get; set; } // text
		[Column,     NotNull    ] public long   PercentsDictionaryId { get; set; } // bigint
		[Column,        Nullable] public long?  WinnerProposalId     { get; set; } // bigint

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
		[PrimaryKey, Identity] public long   UserId   { get; set; } // bigint
		[Column,     NotNull ] public long   RoleId   { get; set; } // bigint
		[Column,     NotNull ] public string Name     { get; set; } // text
		[Column,     NotNull ] public string Email    { get; set; } // text
		[Column,     NotNull ] public string Password { get; set; } // text
		[Column,     NotNull ] public bool   IsActive { get; set; } // boolean

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
		[PrimaryKey, Identity] public long     UserTokenId            { get; set; } // bigint
		[Column,     NotNull ] public long     UserId                 { get; set; } // bigint
		[Column,     NotNull ] public DateTime DateTime               { get; set; } // date
		[Column,     NotNull ] public string   Data                   { get; set; } // text
		[Column,     NotNull ] public DateTime ExpiresAccessDateTime  { get; set; } // date
		[Column,     NotNull ] public DateTime ExpiresRefreshDateTime { get; set; } // date

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
		public static Agent Find(this ITable<Agent> table, long AgentId)
		{
			return table.FirstOrDefault(t =>
				t.AgentId == AgentId);
		}

		public static CustomFeeDictionary Find(this ITable<CustomFeeDictionary> table, long CustomFeeDictionaryId)
		{
			return table.FirstOrDefault(t =>
				t.CustomFeeDictionaryId == CustomFeeDictionaryId);
		}

		public static PercentsDictionary Find(this ITable<PercentsDictionary> table, long PercentsDictionaryId)
		{
			return table.FirstOrDefault(t =>
				t.PercentsDictionaryId == PercentsDictionaryId);
		}

		public static Proposal Find(this ITable<Proposal> table, long ProposalId)
		{
			return table.FirstOrDefault(t =>
				t.ProposalId == ProposalId);
		}

		public static Role Find(this ITable<Role> table, long RoleId)
		{
			return table.FirstOrDefault(t =>
				t.RoleId == RoleId);
		}

		public static Tender Find(this ITable<Tender> table, long TenderId)
		{
			return table.FirstOrDefault(t =>
				t.TenderId == TenderId);
		}

		public static User Find(this ITable<User> table, long UserId)
		{
			return table.FirstOrDefault(t =>
				t.UserId == UserId);
		}

		public static UserToken Find(this ITable<UserToken> table, long UserTokenId)
		{
			return table.FirstOrDefault(t =>
				t.UserTokenId == UserTokenId);
		}
	}
}
