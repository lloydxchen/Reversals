---
video_number: 239
inferred_title: "How To Set Up Orderflows Sequencing In Markers For NinjaTrader 8 Order Flow Trading"
inferred_date: "2022-03-29"
video_id: "03w35Q0a-jI"
source_vtt: "20220329 - How To Set Up Orderflows Sequencing In Markers For NinjaTrader 8 Order Flow Trading [03w35Q0a-jI].en.vtt"
word_count: 1848
segment_count: 306
---

# How To Set Up Orderflows Sequencing In Markers For NinjaTrader 8 Order Flow Trading
*Date:* 2022-03-29  |  *Video ID:* 03w35Q0a-jI  |  *Words:* 1848
*Source VTT:* `20220329 - How To Set Up Orderflows Sequencing In Markers For NinjaTrader 8 Order Flow Trading [03w35Q0a-jI].en.vtt`

---

[00:00] hey everyone it's mike from overflows and in this video i'm going to show you how to set up the order flows sequencing tool in markers from the indicator store you know markers is a great tool for automating your trading and you know question i've gotten recently is you know canopy can the overflow sequencing tool be automated and yes it can in markers so let me take you through the setup really quick now the instructions you can find them in the description below and it's just very easy steps obviously

[00:27] open a new chart or use your existing one you're going to turn on the chart trader choose your atm add order flow sequencing if it's not already there you're going to add markers plus the force you're going to add two copies of markers copy one for the buy one for the cells then you got to go in and set up the buy and sell copies so go into markers plus and change first the working mode to auto enable longs enable shorts enable fast signal modes because you're going to use fast signals

[00:57] you can change the name of the fast signals name to longs for buys and the shorts to shorts so you can you can change it to whatever you want i like to use long as in shorts you could use buys and sells whatever you like it's up to you and the money management you may depend on the market you're trading in this example and we're showing you ultra bonds and ultra bonds is 31.25 a tick and if you're trading micros you probably keep it at 500 but for

[01:24] ultra bonds you know you gotta you gotta make it wider because based on your stop and you take profit you know on ultra bonds i use a stop of uh five ticks so i'm changing it again to 5000 up and down for max daily profit max daily loss again you can set it to a thousand if you want or 750 it's up to you and then let's set up the individual markers copy first to buy go in and change the markers variable name to longs enable fast signal

[01:54] go to data series and add the order flow sequencing with the settings that you use the settings that you use you know you have to set them for both the buys and the cells change the parameters plot for the normal buy signal then you got to change the setup how it's calculated to on each tick from on bar close and then the plots i like to keep it the same as the actual indicator which is blue triangle up eight and same thing for the cells only this time you're doing for this the

[02:25] shorts so you gotta change the name to shorts enable fast signal data series all right you gotta set up the order flow sequencing with the same settings that you use for your buys but this time you're going to change the from normal buy signals to normal sell signal then you're going to calculate change that from on bar close to on each tick and change the plots red triangle down 8. okay now a few last minute checks before trading make sure the atm is selected you turn on auto mode and you

[02:53] make sure the correct account is showing all right so let's take a look at a chart here okay so here i have my normal chart so first thing you're going to do add chart trader if you don't already have it on click apply so it'll show up here and then i'm going to go in and add the indicator and the markers indicator so first go here we'll add the sequencing i'll change it to the settings that i like which is three and zero and keep the trade entry signal on

[03:25] go to the indicator store folder markers plus the force since i'm using markers copy you gotta add two two instances of it one for the buys one for the cells okay so first we'll set up markers of force um the this one here the the time and force you could keep it as gtc just make sure at the end of the day all your orders are cancelled or just change it today working mode change to auto enable longs enable shorts fast signal mode okay so you can see the names here so for

[03:57] long trades i'm going to change it to longs for buys and for cells i'm going to change it to shorts okay and this is in here we could change the max daily loss again if you're trading micros if i just keep it at 500 it's fine but i'm using ultra bonds so it's a bit uh more risk involved okay so for now i'm going to markers copy so i'm going to set up the longs the buy signals right i call them longs enable fast signal change the setup

[04:28] to calculate on each tick and the plots blue solid triangle up eight now the most important step here you got to go into the data series okay and you got to add the indicator in here so go inside open it up sequencing use the same setup same settings that you want to use three no look back this is the buy signal so i'll keep it on buy okay click ok that's the buy now the cells same thing but this time it's the cells so i want to enable fast signal

[05:04] remember i call the cells shorts on each tick um change the color here from blue to red because these are my cells all right um instead of dot i'm going to use triangle down eight and then the most important part here the data series okay so open that up go to the indicators sequencing three turn that off change the plot right because now i'm not plotting the buy signals i'm looking at the cell signals click okay ok now it's all set up so just click apply

[05:43] okay click ok i see here ultrabonds right so last minute checks make sure it's on auto the accounts have to match up all right this one says playback this one says sim i'm using the playback account because i'm showing it to you after the market's closed so change that make sure that this matches this right the account up here matches the account here and choose your atm right click on there ultra bonds right make sure that this matches this so you just click on here and it'll sync

[06:14] with what's there all right so i'm in the playback mode um let me just start it up here uh okay it's showing me over the weekend here let me just speed it up okay let me pause this video while this catches up here okay here so it's coming up on the five o'clock reopen let me just get a little bit closer here to the opening time all right so i'm going to show you the whole trading day i guess um of this is starting from the sunday night

[06:54] uh reopen okay so here's the first trade okay so you can see here when it hits the when it hits the profit it's at 218 because it's a uh in this in this example it's a seven tick take profit and a five tick stop um well let me speed it up here but i'll just run through the whole day so you can see how it was rather than just show one trade now of course you know every day is not going to be as a great day some days might be a little

[07:32] bit lesser some days might have a loss but i just want you to see all the different um trades for this day using this stop and take profit again it's depending on the market that you're trading you know you're going to have a different risk atm than what i'm using right if you're trading obviously if you're trading micros or e-minis you're going to have a different atm strategy okay so there that it was a loss there was there was a trade it took here right then it got reversed out and then so it

[08:05] took us small loss all right now it's you know there's another loss let's stop at 342. all right another stop got triggered all right so now i'm on at -156 so you see it's updating here all right minus 218. you know the thing is when when you're trading auto you know using an auto trader you really have to have your stop and take profit dialed in because you know there's going to be days where you know it seems like nothing

[08:46] can go wrong right every trade is is a winner there's going to be days where it's just it doesn't quite go to your take profit maybe it goes 70 of the way there you know then then comes in and stops you out me personally i like to use markers to get me into the trade and then i can manage it from there you know i i could do the trade management by watching the order flow myself so you can see here there was a bunch of

[09:11] trades that went through you know so i'm down to 156 earlier i was up like 400 bucks right now it's at what plus 218 plus 400. so it's getting here what time is it 10 o'clock in the morning look at that that's a thousand already there's a nice move here sell sell sell see there's some nice again depending on the market you know the one nice thing about you know the tool like markers is you know you can sort of run it through you know the different um

[09:46] atm that you want to try well here it's coming up on the close of the day already two o'clock okay so there's one last trade here so here's three o'clock okay so there four o'clock so that's all there is to it to set it up um you know pretty nice day hundred bucks on a one lot but again you know i i don't want you going out thinking that you know every day is going to be this fantastic um you know friday was also had some nice

[10:27] price movements you know ultra bonds is a great contract but there's there's more to the markets out there than just e-minis and mnq um you know there's there's a lot of great contracts for trading so hopefully you found this video helpful if you haven't yet got the um order flows sequencing tool you just go to orderflows.com sequencing index.html it's kind of a mouthful the link is in the description below so have a great night everybody bye-bye
