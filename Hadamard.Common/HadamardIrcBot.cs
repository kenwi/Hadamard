﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IrcDotNet;
using System.Net;
using Newtonsoft.Json;

namespace Hadamard.Common
{
    public class HadamardIrcBot : IrcBot
    {
        private static string _channel = "#da8Q_9RnPjm";

        public HadamardIrcBot() : base()
        {
            Connect("orwell.freenode.net", RegistrationInfo);
            _commandProcessors = CommandProcessors;
        }

        public override IrcRegistrationInfo RegistrationInfo
        {
            get
            {
                return new IrcUserRegistrationInfo()
                {
                    NickName = "Hadamard",
                    UserName = "Hadamard",
                    RealName = "isReal"
                };
            }
        }

        protected IDictionary<string, CommandProcessor> CommandProcessors
        {
            get
            {
                return _commandProcessors == null ?
                    new Dictionary<string, CommandProcessor>
                    {
                        {
                            "join", (command, parameters) => {
                                if(parameters.Count < 1 )
                                    throw new ArgumentException("Not enough arguments");
                                var channel = parameters[0].StartsWith("#") ? parameters[0] : $"#{parameters[0]}";
                                _client.Channels.Join(channel);
                            }
                        },
                        {
                            "quit", (command, parameters) =>
                            {
                                Quit();
                            }
                        }

                    } : _commandProcessors;
            }
        }

        protected override void InitializeCommandProcessors()
        {

        }

        protected override void OnClientRegistered(IrcClient client)
        {
            base.OnClientRegistered(client);
            client.Channels.Join(_channel);
        }

        protected override void OnChannelMessageReceived(IrcChannel channel, IrcMessageEventArgs e)
        {
            base.OnChannelMessageReceived(channel, e);

            if(e.Text.Equals("satinfo"))
            {
                using (var webClient = new WebClient())
                {
                    var response = webClient.DownloadString("http://www.n2yo.com/sat/instant-tracking.php?s=25338&hlat=70.07436&hlng=29.74872&d=300&r=139203158747.09302&tz=GMT+02:00&O=n2yocom&rnd_str=5b53a06e197ed03f2075e8c1d85fa6d6");
                    dynamic model = JsonConvert.DeserializeObject(response);

                    var satellite = new
                    {
                        NoradId = model[0].id,
                        Latitude = model[0].pos.First.d.ToString().Split('|')[0],
                        Longtitude = model[0].pos.First.d.ToString().Split('|')[1]
                    };
                    var replyMessage = $"Current position latitude: {satellite.Latitude} longtitude: {satellite.Longtitude} norad id: {satellite.NoradId}";
                    _client.LocalUser.SendMessage(_channel, replyMessage);
                }
            }
        }
    }

}
/*
var test = responseModel[0].id;
var pos = responseModel[0].pos;

dynamic position = responseModel[0].pos;
dynamic poss = position.First;

var latitude = poss.d.ToString().Split('|')[0];
var longtitude = poss.d.ToString().Split('|')[1];
*/