using EnrageTgBotILovePchel.Bot.Router;
using Telegram.Bot.Types.ReplyMarkups;

namespace EnrageTgBotILovePchel.Bot;

public class BotMessage
{
    public string Text { get; }
    public IReplyMarkup KeyboardMarkup { get; }
    public bool HideReplyKeyboard { get; }
    public MessageState WhatIsMessageState { get; }
    public TransmittedData? TransmittedData { get; }

    public BotMessage(string text, MessageState messageState, TransmittedData transmittedData = default)
    {
        Text = text;
        KeyboardMarkup = null;
        HideReplyKeyboard = false;
        WhatIsMessageState = messageState;
    }

    public BotMessage(string text, IReplyMarkup keyboardMarkup, MessageState messageState, TransmittedData transmittedData = default)
    {
        Text = text;
        KeyboardMarkup = keyboardMarkup;
        HideReplyKeyboard = false;
        WhatIsMessageState = messageState;
    }

    public BotMessage(string text, IReplyMarkup keyboardMarkup, bool hideReplyKeyboard, MessageState messageState, TransmittedData transmittedData = default)
    {
        Text = text;
        KeyboardMarkup = keyboardMarkup;
        HideReplyKeyboard = hideReplyKeyboard;
        WhatIsMessageState = messageState;
    }
}