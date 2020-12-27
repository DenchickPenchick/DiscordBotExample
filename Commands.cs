using Discord.Commands;
using Discord.WebSocket;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordBotExample
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("Ping")]//This attribute create new command.
        public async Task Pong()
        {
            await ReplyAsync("Pong");//Replying user
        }

        [Command("Kick")]
        public async Task Kick(string mention)//There user enter mention of user
        {
            var user = Context.Message.MentionedUsers.First() as SocketGuildUser;//Geting this user...
            await user.KickAsync();//Kick this user from server :)
            //Nice
        }
    }
}
