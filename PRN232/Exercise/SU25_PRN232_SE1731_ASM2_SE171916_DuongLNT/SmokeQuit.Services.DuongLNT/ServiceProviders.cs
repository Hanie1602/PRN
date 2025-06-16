using SmokeQuit.Services.DuongLNT;

public interface IServiceProviders
{
	SystemUserAccountService UserAccountService { get; }
	QuitPlansAnhDtnDuongLNTService QuitPlansAnhDtnDuongLNTService { get; }
	ILeaderboardsDuongLntService LeaderboardsDuongLntService { get; }
}

public class ServiceProviders : IServiceProviders
{
	private SystemUserAccountService _systemUserAccountService;
	private QuitPlansAnhDtnDuongLNTService _quitPlansAnhDtnDuongLNTService;
	private ILeaderboardsDuongLntService _leaderboardsDuongLntService;

	public ServiceProviders() { }

	public SystemUserAccountService UserAccountService =>
		_systemUserAccountService ??= new SystemUserAccountService();

	public QuitPlansAnhDtnDuongLNTService QuitPlansAnhDtnDuongLNTService =>
		_quitPlansAnhDtnDuongLNTService ??= new QuitPlansAnhDtnDuongLNTService();

	public ILeaderboardsDuongLntService LeaderboardsDuongLntService =>
		_leaderboardsDuongLntService ??= new LeaderboardsDuongLntService();
}
