# landtechnologies

#Given Scinario : Plotting House on Grid based on provided co-ordinates with color which identifies cost range which is relative.

#Getting Started : 

1) Open Visual Studio 2017 as an Administrator.
2) Open SoldPriceMapAPI.sln file. 
3) Running Test:
  1)Right Click on Solution in Solution Explorer and click rebuild.
  2)Click on Test-->Windows-->Test Explorer
  3)Click on Run All. it will run Unit Test.
  4)To see more about test coverage, open SoldPriceMapServiceShould.cs file.
  5) Knowing, text file as infrastructre layer responsibility, i have mocked the input file and compared the service layers                   responsibility.
  
4)Running Application : 
  1) (Optional Step) If not, right click on SoldPriceMapAPI project and set as start up project.
  2) Hit F5 or run application using Play button on the top.
  3) Ensure that API gets hosted as http://localhost:55973/ URL. note that, we have used this url in our Frond end.
  4) Go to Frontend folder and simply open "SoldPriceMap.html" file.
  5) You should able to see result as below.
  ![alt text](https://github.com/ashwini701/landtechnologies/blob/master/Capture.PNG)
  
5)Technical Decisions :
  1) Used DDD(Doamin Driven API architecture) based on understanding as Data will have N number reosurces and plotting logic will be in        Domain.
  2) used Mocking Unit test framework to Mock External resources and check integirity of our application.
  3) There is still scope to cover more on test like, Smoke, integration and Adaptor test. 
  4) There are plenty of JS plug in available like chart.js, plot.ly but instead of going with them choosed to use basic canvas and plot.
  5) Kept simple UI where used Canvas to plot and make use of Canvas object to draw X and Y Axis and plot house as a arch with different      color.
  6) Used XMLHttpRequest object to call API and convert received data to JSON and process in JavaScript Function to plot on Map.

  
