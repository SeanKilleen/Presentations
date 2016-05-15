using System;
using System.Collections.Generic;

using Akka.Actor;

namespace Supervision
{
    #region exceptions

    public class HungryException : Exception
    {
        public HungryException(string message) : base(message) { }
    }

    public class EvilException : Exception
    {
        public EvilException(string message) : base(message) { }
    }

    #endregion

    #region messages

    public class EvilMessage
    {
        public EvilMessage()
        {
            //
        }
    }

    public class HungryMessage
    {
        public HungryMessage()
        {
            //
        }
    }

    public class UpdateRequestMessage
    {
        public IActorRef ReplyTo { get; private set; }
        public UpdateRequestMessage(IActorRef replyTo)
        {
            this.ReplyTo = replyTo;
        }
    }

    public class UpdateRequestReplyMessage
    {
        public string Contents { get; private set; }
        public int Count { get; private set; }
        public string LastMessageId { get; private set; }
        public UpdateRequestReplyMessage(string contents, int count, string lastMessageId)
        {
            this.Contents = contents;
            this.Count = count;
            this.LastMessageId = lastMessageId;
        }
    }

    #endregion

    public enum Mood { Happy, Hungry, Evil }

    public class MinionActor : ReceiveActor
    {
        Random random = new Random();

        public Mood Mood { get; private set; }
        public string Gibberish { get; private set; }
        public string LastMessageId { get; private set; }
        public int MessageCount { get; private set; }

        public MinionActor()
        {
            Mood = Mood.Happy;

            Receive<GibberishMessage>(x =>
            {
                MessageCount++;
                LastMessageId = x.ID;
                Console.WriteLine("{0}: {1}", Self.Path.Name, LastMessageId);
                if (Mood == Mood.Hungry)
                {
                    throw new HungryException("Me want bananaaa!");
                }
                else if (Mood == Mood.Evil)
                {
                    throw new EvilException("You're not the boss of me!");
                }
                else
                {
                    Gibberish = gibberish[random.Next(gibberish.Count)];
                }
            });

            Receive<HungryMessage>(x => Mood = Mood.Hungry);

            Receive<EvilMessage>(x => Mood = Mood.Evil);

            Receive<UpdateRequestMessage>(x => x.ReplyTo.Tell(new UpdateRequestReplyMessage(Gibberish, MessageCount, LastMessageId)));
        }

        protected override void PreRestart(Exception reason, object message)
        {
            // put message back in mailbox for re-processing after restart
            Self.Tell(message);
            Mood = Mood.Happy;
        }

        List<string> gibberish = new List<string>() {
            "Minions ipsum daa para tú jiji.",
            "Underweaaar tank yuuu!",
            "Me want bananaaa!",
            "Para tú chasy uuuhhh bee do bee do bee do chasy.",
            "Baboiii jiji belloo!",
            "Ti aamoo!",
            "Hahaha baboiii underweaaar la bodaaa daa la bodaaa.",
            "Underweaaar gelatooo pepete tatata bala tu.",
            "Jeje underweaaar tank yuuu!",
            "Bee do bee do bee do ti aamoo!",
            "Chasy.",
            "Hahaha gelatooo bananaaaa daa daa me want bananaaa!",
            "Hahaha bee do bee do bee do bappleees tank yuuu!",
            "Wiiiii chasy hana dul sae chasy baboiii la bodaaa.",
            "Jeje pepete tank yuuu!",
            "Aaaaaah po kass.",
            "Jeje uuuhhh tulaliloo daa tatata bala tu jeje belloo!",
            "Jiji.",
            "Tank yuuu!",
            "poulet tikka masala daa para tú po kass aaaaaah bappleees hana dul sae butt.",
            "Jeje tatata bala tu underweaaar jeje butt daa butt po kass hana dul sae.",
            "Underweaaar poulet tikka masala la bodaaa gelatooo bappleees.",
            "La bodaaa ti aamoo!",
            "La bodaaa hahaha poulet tikka masala tulaliloo gelatooo hana dul sae daa butt.",
            "Tatata bala tu para tú ti aamoo!",
            "Baboiii.",
            "Belloo!",
            "hana dul sae aaaaaah hana dul sae tank yuuu!",
            "Bappleees bee do bee do bee do.",
            "Bananaaaa ti aamoo!",
            "Hana dul sae uuuhhh jeje underweaaar aaaaaah uuuhhh hahaha.",
            "Hana dul sae poopayee belloo!",
            "Hahaha bananaaaa para tú para tú.",
            "Poulet tikka masala chasy uuuhhh poulet tikka masala wiiiii poulet tikka masala tulaliloo bappleees jeje tatata bala tu.",
            "Potatoooo jeje bananaaaa underweaaar ti aamoo!",
            "Tatata bala tu bee do bee do bee do ti aamoo!",
            "Jeje jeje belloo!",
            "Bappleees tatata bala tu belloo!",
            "Uuuhhh me want bananaaa!",
            "Potatoooo po kass jeje aaaaaah chasy.",
            "Daa tulaliloo me want bananaaa!",
            "Tulaliloo la bodaaa gelatooo jiji belloo!",
            "Uuuhhh.",
            "Jiji me want bananaaa!",
            "Bappleees bananaaaa bappleees la bodaaa ti aamoo!",
            "Hana dul sae ti aamoo!",
            "La bodaaa tatata bala tu pepete ti aamoo!",
            "Aaaaaah poopayee poulet tikka masala.",
            "Poulet tikka masala aaaaaah aaaaaah belloo!",
            "Poopayee underweaaar.",
            "Bananaaaa po kass tulaliloo bee do bee do bee do butt uuuhhh me want bananaaa!",
            "Bappleees.",
            "Para tú butt wiiiii gelatooo.",
            "Aaaaaah uuuhhh tulaliloo bananaaaa hahaha uuuhhh jiji chasy gelatooo baboiii.",
            "tulaliloo jeje hahaha tulaliloo tulaliloo."
        };
    }
}
