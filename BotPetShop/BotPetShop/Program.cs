using DataAccess.Models;
using Domain.Models;
using Microsoft.Ajax.Utilities.Configuration;
using Newtonsoft.Json;
using System.Globalization;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotPetShop
{
    internal class Program
    {


        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            HttpClient client = new HttpClient();
            var result = await client.GetAsync("https://localhost:7079/api/Products1");

            Console.WriteLine(result);

            var test = await result.Content.ReadAsStringAsync();
            Console.WriteLine(test);

            Products1[] products1 = JsonConvert.DeserializeObject <Products1[]>(test);

            foreach(var product in products1)
            {
                Console.WriteLine(product.CategoryId + " " + product.Title + " " + product.Cost);
            }

            var botClient = new TelegramBotClient("6183309262:AAFWEGTA5NHuZv9VmljstHsSHH4U-uk_6DA");

            using CancellationTokenSource cts = new();

            //StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>() //receive all update types
            };

            botClient.StartReceiving(
                updateHandler: HadleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );

            var me = await botClient.GetMeAsync();

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            //Send canclellation request to stop bot
            cts.Cancel();
        }
        static async Task HadleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            //Only process Message updates: https://core.telegram.org/bots/api#message
            if (update.Message is not { } message)
                return;
            //Only process text message
            if (message.Text is not { } messageText)
                return;

            var chatId = message.Chat.Id;

            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

            //Echo received message text
            Message sentMessage = await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "You said:\n" + messageText,
                cancellationToken: cancellationToken);

            if (message.Text == "Проверка")
            {
                await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "Проверка: ОК!",
                cancellationToken: cancellationToken);
            }

            if (message.Text == "Привет")
            {
                await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "Добро пожаловать в интернет-зоомагазин Лапка",
                cancellationToken: cancellationToken);
            }

            if (message.Text == "Картинка")
            {
                await botClient.SendPhotoAsync(
                chatId: chatId,
                photo: "https://thumbs.dreamstime.com/b/%D0%B7%D0%BE%D0%BE%D0%BC%D0%B0%D0%B3%D0%B0%D0%B7%D0%B8%D0%BD-%D0%B0%D0%BA%D1%81%D0%B5%D1%81%D1%81%D1%83%D0%B0%D1%80%D1%8B-%D0%B8-%D0%BC%D0%B0%D0%B3%D0%B0%D0%B7%D0%B8%D0%BD-%D0%B2%D0%B5%D1%82%D0%B5%D1%80%D0%B8%D0%BD%D0%B0%D1%80%D0%B0-78935614.jpg",
                cancellationToken: cancellationToken);
            }

            if (message.Text == "Видео")
            {
                await botClient.SendVideoAsync(
                chatId: chatId,
                video: ("https://github.com/kleymenovaTatiana/-/raw/main/Сеть%20магазинов%20Бетховен%20(360p).mp4"),
                supportsStreaming: true,
                cancellationToken: cancellationToken);
            }

            if (message.Text == "Стикер")
            {
                await botClient.SendStickerAsync(
                chatId: chatId,
                sticker: ("https://raw.githubusercontent.com/kleymenovaTatiana/-/main/dc0dffa5b90dab3342d1b7628b4ec201.webp"),
                cancellationToken: cancellationToken);
            }
            ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
            {
                KeyboardButton.WithRequestLocation("Share Location"),
                KeyboardButton.WithRequestContact("Share Contact"),
            });

            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "Who or Where are you?",
                replyMarkup: replyKeyboardMarkup,
                cancellationToken: cancellationToken);
        }
        static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}