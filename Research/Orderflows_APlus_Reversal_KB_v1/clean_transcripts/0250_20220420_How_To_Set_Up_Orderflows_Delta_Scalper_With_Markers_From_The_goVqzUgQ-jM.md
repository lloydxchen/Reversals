---
video_number: 250
inferred_title: "How To Set Up Orderflows Delta Scalper With Markers From The Indicator Store"
inferred_date: "2022-04-20"
video_id: "goVqzUgQ-jM"
source_vtt: "20220420 - How To Set Up Orderflows Delta Scalper With Markers From The Indicator Store [goVqzUgQ-jM].en.vtt"
word_count: 1804
segment_count: 260
---

# How To Set Up Orderflows Delta Scalper With Markers From The Indicator Store
*Date:* 2022-04-20  |  *Video ID:* goVqzUgQ-jM  |  *Words:* 1804
*Source VTT:* `20220420 - How To Set Up Orderflows Delta Scalper With Markers From The Indicator Store [goVqzUgQ-jM].en.vtt`

---

[00:00] hey everybody it's Mike from order flows and I'm shooting this quick video you know because a few people have asked me how to set up uh the order flows Delta scalper indicator in markers okay so the order flows Delta scalper runs on ninjatrader 8 as well as markers markers is a tool from uh Pablo at the indicator store that will allow you to automate the trading aspect of using the Delta scalper okay so let's uh let's jump in so first thing you got to do obviously

[00:30] is um you know you want to open a chart and you're going to add the indicator and add markers so let's uh go through the steps here it's really very simple if you're familiar with markers you understand what you need to do but for people that are new to markers you know this is a nice quick video on how to get started so what you're going to do is you're going to add the indicator set the settings you know how you like it so I'm going to add the order flows Delta

[00:57] scalper first then I'm gonna go to the folder with Mark markers and I'm going to add markers plus the force I'm going to add copy one for a copy for the buys one for the cells because I'm going to use the fast copy and markers all right so you should have the Delta scalper you're going to have markers plus the force markers copy one for the buys one for the cells all right so let's go and set up markers alrighty so what I'm going to do is I'm

[01:25] going to go in and set up the automation part so the type of order it's going to be a day order and I'm going to enable Longs enables shorts and fast signals because I'm going to be using the fast signals mode okay and for fast signals it's going to be called Longs right your buy signals I'm going to call my cell signals shorts okay and let's show you how what that means in a minute um now you could show the p l if you want max daily loss max daily profit you

[01:58] know set it at a thousand um you know I'm using the mes so it's uh you know a thousand either way is is you know quite big moves you don't really need to change anything else in here okay um I'll talk about later about the ATM and you know make sure the account is set so let's set up the buys and the cells so the first one markers copy um this is gonna be called long so I'm going to change the markers the new markers variable from my line to Longs

[02:28] okay I'm going to enable fast signal okay I want to change the setup calculate on each tick and I'm going to change you know how it's plotted um for Buys so it's going to be blue solid this is a buy it's going to be a triangle up and I like to make it a little bit big I keep this the same as what I use for the indicator in there so it's which is uh buys our blue solid triangle up now the most important setting is this one the data Series

[02:57] right it says in this case it says mes but you have to change the input series you have to change it to the indicator so you got to go in here you click on right so here I'll just show you that real quick you click on this box edit input right and pulls this up find the indicator right order flows Delta scalper now again set it to the settings that you prefer okay because this is just going to be the default settings um it's going to plot the positive Delta

[03:23] change okay positive Delta change is for Buys so click ok and that one is set up now for the cells and cells are the name is shorts enable fast signal use fast signal change the setup calculate on each tick and I'm going to change the plots from Blue since it's cell uh this is cells so it's going to be red solid triangle down okay change the size to eight and I gotta set up the data series the input series okay so open that up click on the indicator

[04:01] go in here to Delta scalper okay change the settings you like so I can change that to look back to zero and here the plot right positive Delta that's where the buys negative Delta change is for the cells Okay click OK right so that's it basically so shorts okay Longs this is all set up in here lungs for buys shorts for cells click apply okay now you can see all the stuff gets filled in up here at the top now what you need to do make sure your ATM

[04:35] make sure you have chart Trader enabled okay make sure you choose the ATM that you're going to use this is my mes 13 by what is that 26. click this up here where it says select the valid so make sure this name is the same as the name over here now this is I'm in playback mode so account is playback make sure the same account matches up here playback playback I'll use the auto mode so I'm going to change this where it says off this is going to be automatic okay

[05:04] now since I'm in playback mode okay I'm going to run the playback here uh okay it should start running faster what am I at 8X that's kind of slow so I'm starting this on what the 17th showing you a couple of days so let's just speed it up here because some playback after all so you can see what the daily p l is what the last trade is going to be okay so it's kind of quick so it's there you see it took one trade then there was a short that came in so

[05:41] it got short you can see it running already you know if I put it to 500 it's about fast enough okay so it's been a couple trades so far all right last trade 17 daily p l is at minus five right now [Music] but again you know it's up to you to set what your uh ATM is going to be um you know what your your stop is going to be what your take profit is going to be now me personally I like to watch the order flow in

[06:21] addition to just getting in and leaving the stop or take profit in I like to manage the trades you know I don't trade 100 different markets so I don't need to have this thing running um all the time right you know like I could sit there and I could manage the trades right I like I trade order flows I like to watch what the order flow is doing and if it starts going against me or if I see the order flow changing rather than going and stopping me out I just

[06:46] get out of the trade right there's nobody putting a gun to your head that says oh you know what you have to let the trade go to your target or you have to let it go to your take profit you know what if the order flow starts changing that's your sign to you know get out of the trade basically so you can see here how it's how it's running um you know so far since midnight up till eight o'clock it's trading the micros the mes it's what 36 bucks again the

[07:18] micros is a very small contract so again you know I'm using my my stop is 13 ticks my take profit is uh 26 ticks okay so obviously I got stopped out there so if I have a loop I get stopped out at the full stop you know it's like 16 bucks but if it goes to my take profit it's like 31 bucks so you see it got two stop outs uh in a row

[08:00] so I'm back down to just five dollars order filmed order filmed so you see is there somewhere and I have a short but then a long signal will come in so it'll just it'll exit the trade and get you into the new trade whoops sorry I dropped my phone because you're wondering that was I didn't like fall over um Okay so

[08:42] uh where are we at right now so time is it it's 12 30 it's up about 100 bucks in the micros the mes now granted you know this was on Monday the um 18th you know which was a nice uh a nice nice Trends up and down I know late in the day if you remember on Monday um we had that monster move up on the close basically but this is you know going up until two o'clock you know it's up trading micros 196 bucks now granted not every day is

[09:20] going to be like that I wish every day is going to be like that someday's gonna have losing days some days you're gonna have small winning days some days have small losing day some days you're going to have bigger losing days you know trading is it's like sports sometimes it all sometimes averages out okay so here you see that it's got that nice big move up um late in the day okay so you know I'll end it there it's four o'clock in the afternoon so you can

[09:51] see how easy it is to set up in markers and get running right this whole video so far is not even 10 minutes long it's like 9 Minutes 57 seconds and a lot of it was just showing it in replay to set it up just literally took a couple of minutes it's very simple uh steps to follow so um you know if you enjoyed this video right um you know just hit the like button right I'll be happy to create more videos just let me know if there's

[10:16] something you want to see um be sure to subscribe to the channel so when I post new new videos on the channel you'll get the notifications to see them um that's what keeps me doing this uh making these videos so have a great day everyone now you understand how to use markers from the indicator store with um the order flows Delta scalper bye-bye
