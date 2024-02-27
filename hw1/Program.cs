Account myAccount = new Account(1000);
SMSLowBalanceNotifyer sms = new SMSLowBalanceNotifyer("89831330902", 100);
EMailBalanceChangedNotifyer email = new EMailBalanceChangedNotifyer("edmitriev377@gmail.com");

myAccount.AddNotifyer(sms);
myAccount.AddNotifyer(email);

myAccount.ChangeBalance(-1000);
myAccount.ChangeBalance(100);
myAccount.ChangeBalance(10000);
myAccount.ChangeBalance(-10080);
myAccount.ChangeBalance(367);

class Account{
    private decimal _balance;
    private List<INotifyer> _notifers;

    public Account(){
        _balance = 0;
        _notifers = new List<INotifyer>();
    }

    public Account(decimal _balance){
        this._balance = _balance;
        _notifers = new List<INotifyer>();
    }

    public void AddNotifyer(INotifyer notifiyer){
        _notifers.Add(notifiyer);
    }

    public void ChangeBalance(decimal value){
        _balance += value;
        Notification();
    }

    public decimal Balance{
        get
        {
            return _balance;
        }
    }

    private void Notification(){
        foreach (var notifyer in _notifers)
        {
            notifyer.Notify(_balance);
        }
    }
}

interface INotifyer{
    public void Notify(decimal balance){}
}

class SMSLowBalanceNotifyer :INotifyer{
    private string _phone;
    private decimal _lowBalanceValue;

    public SMSLowBalanceNotifyer(string phone, decimal lowBalanceValue){
        _phone = phone;
        _lowBalanceValue = lowBalanceValue;
    }

    public void Notify(decimal balance){
        if (balance < _lowBalanceValue){
            Console.WriteLine("\nSMSLowBalanceNotifyer");
            Console.WriteLine($"Your balance: {balance}");
        }
    }
}

class EMailBalanceChangedNotifyer : INotifyer{
    private string _email;

    public EMailBalanceChangedNotifyer(string email){
        _email = email;
    }

    public void Notify(decimal balance){
        Console.WriteLine("\nEMailBalanceChangedNotifyer");
        Console.WriteLine($"Your balance: {balance}");
    }
}