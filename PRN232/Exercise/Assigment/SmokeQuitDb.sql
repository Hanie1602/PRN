USE master
GO

-- Xóa database nếu tồn tại
IF DB_ID('SU25_PRN232_SE1731_G6_SmokeQuit') IS NOT NULL
    DROP DATABASE SU25_PRN232_SE1731_G6_SmokeQuit
GO

-- Tạo database
CREATE DATABASE SU25_PRN232_SE1731_G6_SmokeQuit
GO

USE SU25_PRN232_SE1731_G6_SmokeQuit
GO

CREATE TABLE [dbo].[System.UserAccount](
	[UserAccountID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[EmployeeCode] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
	[RequestCode] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ApplicationCode] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_System.UserAccount] PRIMARY KEY CLUSTERED 
(
	[UserAccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[System.UserAccount] ON 
GO
INSERT [dbo].[System.UserAccount] ([UserAccountID], [UserName], [Password], [FullName], [Email], [Phone], [EmployeeCode], [RoleId], [RequestCode], [CreatedDate], [ApplicationCode], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1, N'acc', N'@a', N'Accountant', N'Accountant@', N'0913652742', N'000001', 2, NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[System.UserAccount] ([UserAccountID], [UserName], [Password], [FullName], [Email], [Phone], [EmployeeCode], [RoleId], [RequestCode], [CreatedDate], [ApplicationCode], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (2, N'auditor', N'@a', N'Internal Auditor', N'InternalAuditor@', N'0972224568', N'000002', 3, NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[System.UserAccount] ([UserAccountID], [UserName], [Password], [FullName], [Email], [Phone], [EmployeeCode], [RoleId], [RequestCode], [CreatedDate], [ApplicationCode], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (3, N'chiefacc', N'@a', N'Chief Accountant', N'ChiefAccountant@', N'0902927373', N'000003', 1, NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[System.UserAccount] OFF
GO

-- Bảng phụ: MembershipPlansAnhDTN
-- Lưu trữ thông tin các gói thành viên của hệ thống
CREATE TABLE MembershipPlansAnhDTN (
    [MembershipPlansAnhDTNID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL, -- ID duy nhất của gói thành viên
    [PlanName] [nvarchar](50) NOT NULL, -- Tên gói thành viên
    [Description] [nvarchar](max) NULL, -- Mô tả chi tiết về gói thành viên
    [Price] [float] NOT NULL, -- Giá của gói thành viên (VNĐ)
    [DurationDays] [int] NOT NULL, -- Thời hạn gói (số ngày)
    [CreatedAt] [datetime] NULL, -- Thời điểm tạo bản ghi
)
GO

-- Bảng phụ: CoachesLocDPX
-- Lưu trữ thông tin huấn luyện viên tư vấn cai thuốc
CREATE TABLE CoachesLocDPX (
    [CoachesLocDPXID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL, -- ID duy nhất của huấn luyện viên
    [FullName] [nvarchar](100) NOT NULL, -- Họ và tên huấn luyện viên
    [Email] [varchar](100) UNIQUE NOT NULL, -- Email liên hệ của huấn luyện viên
    [PhoneNumber] [varchar](20) NULL, -- Số điện thoại liên hệ
    [Bio] [nvarchar](max) NULL, -- Tiểu sử hoặc thông tin giới thiệu huấn luyện viên
    [CreatedAt] [datetime] NULL, -- Thời điểm tạo bản ghi
)
GO

-- Bảng phụ: AchievementNhuNQ
-- Lưu trữ thông tin các huy hiệu thành tích
CREATE TABLE AchievementNhuNQ (
    [AchievementNhuNQID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL, -- ID duy nhất của huy hiệu
    [AchievementName] [nvarchar](100) NOT NULL, -- Tên huy hiệu
    [Description] [nvarchar](max) NULL, -- Mô tả chi tiết về huy hiệu
    [CriteriaType] [nvarchar](50) NOT NULL, -- CHECK ([CriteriaType] IN ('Days_Smoke_Free', 'Money_Saved', 'Other')), -- Loại tiêu chí
    [CriteriaValue] [float] NOT NULL, -- Giá trị tiêu chí
    [CreatedAt] [datetime] NULL, -- Thời điểm tạo bản ghi
)
GO

-- Bảng phụ: SupportMethodsHoangPX
-- Lưu trữ danh sách các phương pháp hỗ trợ cai thuốc để người dùng chọn
CREATE TABLE SupportMethodsHoangPX (
    [SupportMethodsHoangPXID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL, -- ID duy nhất của phương pháp hỗ trợ
    [MethodName] [nvarchar](100) NOT NULL, -- Tên phương pháp
    [Description] [nvarchar](max) NULL, -- Mô tả chi tiết về phương pháp hỗ trợ
)
GO

-- Bảng chính 1: QuitPlansAnhDTN
-- Lưu trữ kế hoạch cai thuốc của người dùng
CREATE TABLE QuitPlansAnhDTN (
    [QuitPlansAnhDTNID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL, -- ID duy nhất của kế hoạch cai thuốc
    [UserId] [int] NOT NULL, -- ID người dùng sở hữu kế hoạch
    [MembershipPlanId] [int] NULL, -- ID gói thành viên liên kết
    [Reason] [nvarchar](max) NOT NULL, -- Lý do muốn cai thuốc
    [StartDate] [datetime] NOT NULL, -- Ngày bắt đầu kế hoạch
    [ExpectedQuitDate] [datetime] NULL, -- Ngày dự kiến cai thành công
    [DailyCigaretteTarget] [int] NULL, -- Mục tiêu số điếu thuốc mỗi ngày
    [WeeklyCheckinFrequency] [int] NULL, -- Tần suất kiểm tra hàng tuần
    [MotivationalMessage] [nvarchar](max) NULL, -- Tin nhắn động viên cá nhân
    [HealthGoals] [nvarchar](max) NULL, -- Mục tiêu sức khỏe
    [BudgetSavingGoal] [float] NULL, -- Mục tiêu tiết kiệm tiền
    [ReceiveMotivationReminder] [bit] NOT NULL, -- Nhận nhắc nhở động viên
    [IsCustomizedPlan] [bit] NOT NULL, -- Kế hoạch tùy chỉnh
    [CreatedAt] [datetime] NULL, -- Thời điểm tạo bản ghi
    [UpdatedAt] [datetime] NULL, -- Thời điểm cập nhật bản ghi
    FOREIGN KEY ([MembershipPlanId]) REFERENCES MembershipPlansAnhDTN ([MembershipPlansAnhDTNID]),
	FOREIGN KEY ([UserId]) REFERENCES [System.UserAccount] ([UserAccountID])
)
GO

-- Bảng chính 2: ProgressRecordsHoangPX
-- Lưu trữ tiến trình cai thuốc của người dùng
CREATE TABLE ProgressRecordsHoangPX (
    [ProgressRecordsHoangPXID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL, -- ID duy nhất của bản ghi tiến trình
    [UserId] [int] NOT NULL, -- ID người dùng sở hữu tiến trình
    [SupportMethodId] [int] NULL, -- ID phương pháp hỗ trợ được chọn
    [CigarettesSmoked] [int] NULL, -- Số điếu thuốc hút trong ngày
    [HealthStatus] [nvarchar](max) NULL, -- Mô tả tình trạng sức khỏe
    [MoneySaved] [float] NULL, -- Số tiền tiết kiệm được
    [DaysSmokeFree] [int] NULL, -- Số ngày không hút thuốc liên tục
    [RecordedAt] [datetime] NOT NULL, -- Thời điểm tiến trình được ghi nhận
    [Mood] [nvarchar](50) NULL, -- CHECK ([Mood] IN ('Positive', 'Neutral', 'Negative')), -- Tâm trạng hiện tại
    [HadCraving] [bit] NOT NULL, -- Người dùng có cảm giác thèm thuốc
    [CravingLevel] [int] NULL CHECK ([CravingLevel] >= 1 AND [CravingLevel] <= 10), -- Mức độ thèm thuốc
    [Notes] [nvarchar](max) NULL, -- Ghi chú cá nhân về tiến trình
    [ModifiedAt] [datetime] NULL, -- Thời điểm sửa bản ghi
    FOREIGN KEY ([SupportMethodId]) REFERENCES SupportMethodsHoangPX ([SupportMethodsHoangPXID]),
	FOREIGN KEY ([UserId]) REFERENCES [System.UserAccount] ([UserAccountID])
)
GO

-- Bảng chính 3: BlogPostsAnVT
-- Lưu trữ bài viết blog chia sẻ kinh nghiệm cai thuốc
CREATE TABLE BlogPostsAnVT (
    [BlogPostsAnVTID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL, -- ID duy nhất của bài viết
    [UserId] [int] NOT NULL, -- ID người dùng đăng bài
    [PlanId] [int] NULL, -- ID kế hoạch cai thuốc liên quan
    [Title] [nvarchar](255) NOT NULL, -- Tiêu đề bài viết
    [Content] [nvarchar](max) NOT NULL, -- Nội dung bài viết
    [Category] [nvarchar](50) NULL, -- CHECK ([Category] IN ('Experience', 'Tips', 'Motivation', 'Other')), -- Danh mục bài viết
    [Tags] [nvarchar](255) NULL, -- Từ khóa liên quan
    [IsPublic] [bit] NOT NULL, -- Bài viết công khai hay riêng tư
    [ViewsCount] [int] NULL, -- Số lượt xem bài viết
    [LikesCount] [int] NULL, -- Số lượt thích bài viết
    [CommentsCount] [int] NULL, -- Số bình luận trên bài viết
    [CreatedAt] [datetime] NULL, -- Thời điểm tạo bản ghi
    [UpdatedAt] [datetime] NULL, -- Thời điểm cập nhật bản ghi
    FOREIGN KEY ([PlanId]) REFERENCES QuitPlansAnhDTN ([QuitPlansAnhDTNID]),
	FOREIGN KEY ([UserId]) REFERENCES [System.UserAccount] ([UserAccountID])
)
GO

-- Bảng chính 4: ChatsLocDPX
-- Lưu trữ các cuộc trò chuyện giữa người dùng và huấn luyện viên
CREATE TABLE ChatsLocDPX (
    [ChatsLocDPXID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL, -- ID duy nhất của tin nhắn
    [UserId] [int] NOT NULL, -- ID người dùng tham gia trò chuyện
    [CoachId] [int] NOT NULL, -- ID huấn luyện viên tham gia trò chuyện
    [Message] [nvarchar](max) NOT NULL, -- Nội dung tin nhắn
    [SentBy] [nvarchar](10) NOT NULL, -- CHECK ([SentBy] IN ('User', 'Coach')), -- Người gửi tin nhắn
    [MessageType] [nvarchar](10) NOT NULL, -- CHECK ([MessageType] IN ('Text', 'Image')), -- Loại tin nhắn
    [IsRead] [bit] NOT NULL, -- Tin nhắn đã được đọc chưa
    [AttachmentUrl] [nvarchar](255) NULL, -- Đường dẫn tệp đính kèm
    [ResponseTime] [datetime] NULL, -- Thời gian phản hồi
    [CreatedAt] [datetime] NULL, -- Thời điểm tạo bản ghi
    FOREIGN KEY ([CoachId]) REFERENCES CoachesLocDPX ([CoachesLocDPXID]),
    FOREIGN KEY ([UserId]) REFERENCES [System.UserAccount] ([UserAccountID])
)
GO

-- Bảng chính 5: UserAchievementNhuNQ
-- Lưu trữ các thành tích (huy hiệu) mà người dùng đạt được
CREATE TABLE UserAchievementNhuNQ (
    [UserAchievementNhuNQID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL, -- ID duy nhất của bản ghi thành tích
    [UserId] [int] NOT NULL, -- ID người dùng đạt thành tích
    [AchievementId] [int] NOT NULL, -- ID huy hiệu thành tích
    [AchievedAt] [datetime] NOT NULL, -- Thời điểm đạt được thành tích
    [Shared] [bit] NOT NULL, -- Thành tích đã được chia sẻ chưa
    [NotificationSent] [bit] NOT NULL, -- Đã gửi thông báo về thành tích chưa
    [RewardPoints] [int] NULL, -- Điểm thưởng nhận được
    [CommentCount] [int] NULL, -- Số bình luận về thành tích
    [LikeCount] [int] NULL, -- Số lượt thích thành tích
    [CreatedAt] [datetime] NULL, -- Thời điểm tạo bản ghi
    FOREIGN KEY ([AchievementId]) REFERENCES AchievementNhuNQ ([AchievementNhuNQID]),
	FOREIGN KEY ([UserId]) REFERENCES [System.UserAccount] ([UserAccountID])
)
GO

-- Bảng chính 6: Leaderboards - Dương
-- Lưu trữ bảng xếp hạng thành tích của người dùng
CREATE TABLE LeaderboardsDuongLNT (
    LeaderboardsDuongLNTID [int] PRIMARY KEY IDENTITY(1,1) NOT NULL, -- ID duy nhất của bản ghi xếp hạng
    UserId [int] NOT NULL, -- ID người dùng trên bảng xếp hạng
    PlanId [int], -- ID kế hoạch cai thuốc liên quan
    DaySmokeFree [int], -- Số ngày không hút thuốc
    MoneySave [float] DEFAULT 0.00, -- Số tiền tiết kiệm được
    RankPosition [int], -- Vị trí trên bảng xếp hạng
    TotalAchievements [int] DEFAULT 0, -- Tổng số thành tích đạt được
    ProgressScore [float], -- Điểm tiến trình tổng hợp
    Note [nvarchar](255) NULL, -- Ghi chú cho xếp hạng hoặc lý do điều chỉnh
    StreakCount [int] DEFAULT 0, -- Chuỗi ngày liên tục không hút
    CommunityContribution [int] DEFAULT 0, -- Điểm đóng góp cộng đồng (ví dụ: số bài đăng)
    IsTopRanked [bit] DEFAULT 0,		-- Gắn cờ nếu người này từng đứng top 1
    LastUpdate [datetime],	-- Lần cuối bảng này được cập nhật từ process
    CreatedTime [datetime] DEFAULT CURRENT_TIMESTAMP, -- Thời điểm tạo bản ghi
    FOREIGN KEY ([PlanId]) REFERENCES QuitPlansAnhDTN ([QuitPlansAnhDTNID]),
	FOREIGN KEY ([UserId]) REFERENCES [System.UserAccount] ([UserAccountID])
);
GO