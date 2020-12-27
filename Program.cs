using Discord.Addons.BotConstructor;
using System;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord.Commands;
using Discord;

namespace DiscordBotExample
{
    class Program
    {
        private static Bot Bot { get; set; }

        static void Main(string[] args)
        {
            FilesProvider.SetupFiles();//Setup config.json. It isn't necessarily, you can meta data by another way like xml document or entering token/prefix to arguments without file work.
            Bot = new Bot(FilesProvider.Token());//Initilizing new Bot
            //Subscribing on events
            Bot.Client.Ready += Client_Ready;
            Bot.Client.MessageReceived += Client_MessageReceived;
            //Starting bot if token doesn't equal default.
            if(FilesProvider.Token() != "SET ME IN CONFIG")
                Bot.RunBotAsync().GetAwaiter().GetResult();
        }
        
        //Fired when we ready to do something
        private static Task Client_Ready()
        {
            Console.WriteLine("Ready");
            return Task.CompletedTask;
        }

        //Fired when we receive message
        private async static Task Client_MessageReceived(SocketMessage arg)
        {
            int argPos = 0;
            var message = arg as SocketUserMessage;
            var context = new SocketCommandContext(Bot.Client, message);

            if (message.HasStringPrefix(FilesProvider.Prefix(), ref argPos))//If message has string prefix we excute...
            {
                var result = await Bot.CommandService.ExecuteAsync(context, argPos, Bot.Services);//Excuting...

                if (!result.IsSuccess)//If something went wrong...
                {
                    await context.Channel.SendMessageAsync(embed: new EmbedBuilder
                    {
                        Description = "Error",
                        Color = Color.Red
                    }.Build());
                    Console.WriteLine("Error");
                }
                else
                    Console.WriteLine("Succesfull");
                //Nice
            }
        }
    }
}
