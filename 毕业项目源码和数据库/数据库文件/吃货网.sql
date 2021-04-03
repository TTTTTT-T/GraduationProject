create database ChowhoundNet 
use ChowhoundNet

create table UserInfo --�û���Ϣ
(
   userID int primary key identity(1,1),
   Account varchar(20),--����/�ǳ�
   UName nvarchar(20),
   discriptss nvarchar(max),
   userpic nvarchar(max),--ͷ��ͼƬ·�� 
   phone int,--�ֻ���
   pwd varchar(20),--����
   sex char(2),--�Ա�
   Birthday nvarchar(20),--����
   isDelete int default(0)--�Ƿ�ɾ��,0Ϊ��ʾ��1Ϊ����
)
create table Typetypes--�������ͱ�
(
   TypetypesID int primary key identity(1,1),
   TypetypesName nvarchar(50),
  isDelete int default(0)--�Ƿ�ɾ��,0Ϊ��ʾ��1Ϊ����
)
create table Menuinformation --����������Ϣ
(
MenuinformationID int primary key identity(1,1),--����ID
MenuinformationName varchar(50),--��������
abstractss nvarchar(MAX),--ժҪ
TypeName varchar(50),--��Ӱ����
Technology varchar(50),--����
yield varchar(50),--����
MenuinformationImg nvarchar(MAX),--ͼƬ·��
Dishes varchar(50),--��ζ
userID int foreign key(userID) references userinfo(userID),--ȡ�û�����
 TypetID int foreign key(TypetID) references Typetypes(TypetypesID), --ȥ��������
difficulty varchar(50),--ˮƽ
Setuptime varchar(50),--׼��ʱ��
CookingTime varchar(50),--���ʱ��
People  varchar(50),--����
Ingredients varchar(50),--����
directions nvarchar(MAX),--����
calorie varchar(50),--��·��
carbohydrate varchar(50),--̼ˮ������
eggwhite varchar(50),--����
cholesterol varchar(50),--���̴�
fat varchar(50),--֬��
commenttime nvarchar(20)default(getdate()),   --����ʱ��
viewscount int,--�������
isDelete int default(0)--�Ƿ�ɾ��,0Ϊ��ʾ��1Ϊ����
)
create table BuImage(
BuImageID int primary key identity(1,1),
proceduress int,
BuImageimge nvarchar(Max),
discriptss nvarchar(Max),
MenuinformationID int foreign key(MenuinformationID) references Menuinformation(MenuinformationID),  
isDelete int default(0)--�Ƿ�ɾ��,0Ϊ��ʾ��1Ϊ����
)


create table CommentMenu
(
CommentMenuID int primary key identity(1,1),--����ID
contentss nvarchar(max),--��������
userID int foreign key(userID) references userinfo(userID),--ȡ�û�����
MenuinformationID int foreign key(MenuinformationID) references Menuinformation(MenuinformationID),   --ȡ��������
commenttime nvarchar(20)default(getdate()),   --����ʱ��
isDelete int default(0)--�Ƿ�ɾ��,0Ϊ��ʾ��1Ϊ����

)
--�����Ҳ��ױ�
create table publish(
publishID int primary key identity(1,1),
publishName nvarchar(MAX),--�����Ҳ�������
publishImg nvarchar(MAX),--ͼƬ·��
userID int foreign key(userID) references userinfo(userID),--ȡ�û�����
commenttime nvarchar(20)default(getdate()),   --����ʱ��
)
create table Comment --���۱�
(
cID int primary key identity(1,1),
CTechnology varchar(50),--����
CDishes varchar(50),--��ζ
Cdifficulty varchar(50),--�Ѷ�
CSetuptime varchar(50),--׼��ʱ��
CCookingTime varchar(50),--���ʱ��
CPeople  varchar(50),--����
CMenuinformationImg nvarchar(MAX),--ͼƬ·��
CIngredients varchar(50),--����
Csubsidiary varchar(50),--����
userID int foreign key(userID) references userinfo(userID),--ȡ�û�����
publishID int foreign key(publishID) references publish(publishID),   --ȡ��������
commenttime nvarchar(20)default(getdate()),   --����ʱ��

)
create table HotList --������
(
   hlid int primary key identity(1,1),
   hlid int foreign key(MenuinformationID) references Menuinformation(MenuinformationID),--��Ӱ��Ϣ

)
