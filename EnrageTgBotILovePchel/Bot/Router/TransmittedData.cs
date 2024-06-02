namespace EnrageTgBotILovePchel.Bot.Router;

public class TransmittedData
{
    public string State { get; set; }
    public DataStorage DataStorage { get; set; }
    public long ChatId { get; }
    public int MessageId { get; set; }

    public TransmittedData(long chatId, int messageId = 0)
    {
        ChatId = chatId;
        State = States.StartMenu.CommandStart;
        DataStorage = new DataStorage();
        MessageId = messageId;
    }
}