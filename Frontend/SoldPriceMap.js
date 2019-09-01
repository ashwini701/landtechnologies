var grid_size = 10;
var x_axis_distance_grid_lines = 0;
var y_axis_distance_grid_lines = 0;
var canvas = document.getElementById("my-canvas");
var ctx = canvas.getContext("2d");

var canvas_width = canvas.width;
var canvas_height = canvas.height;

var num_lines_x =100;
var num_lines_y =100;

for(var i=0; i<=num_lines_x; i++) {
    ctx.beginPath();
    ctx.lineWidth = 1;    
    
    if(i == 40) {
                ctx.strokeStyle = "red";}
    else
        ctx.strokeStyle = "#d3d3d3";
    
    if(i == num_lines_x) {
        ctx.moveTo(0, grid_size*i);
        ctx.lineTo(canvas_width, grid_size*i);
    }
    else {
        ctx.moveTo(0, grid_size*i+0.5);
        ctx.lineTo(canvas_width, grid_size*i+0.5);
    }
    ctx.stroke();
}

for(i=0; i<=num_lines_y; i++) {
    ctx.beginPath();
    ctx.lineWidth = 1;
    if(i == y_axis_distance_grid_lines) 
        ctx.strokeStyle = "red";
    else
        ctx.strokeStyle = "green";
    
    if(i == num_lines_y) {
        ctx.moveTo(grid_size*i, 0);
        ctx.lineTo(grid_size*i, canvas_height);
    }
    else {
        ctx.moveTo(grid_size*i+0.5, 0);
        ctx.lineTo(grid_size*i+0.5, canvas_height);
    }
    ctx.stroke();
}
var xmlhttp = new XMLHttpRequest();
xmlhttp.onreadystatechange = function() {
    if (this.readyState == 4 && this.status == 200) {
        var HouseData = JSON.parse(this.responseText);
        PlotHouseOnMap(HouseData);
    }
}; 
 xmlhttp.open("get", "http://localhost:55973/api/v1/SoldPriceMapData", false);
 xmlhttp.send();
function PlotHouseOnMap(HouseData) {
  
    for(i = 0; i < HouseData.houses.length; i++) {
        if(Number(HouseData.houses[i].costGroupRange) >= 0 && Number(HouseData.houses[i].costGroupRange) < 5 )
       { ctx.fillStyle = "yellow";   } 
else if (Number(HouseData.houses[i].costGroupRange) >= 5 && Number(HouseData.houses[i].costGroupRange) < 25  )
   { ctx.fillStyle = "blue";}
   else if (Number(HouseData.houses[i].costGroupRange) >= 25 && Number(HouseData.houses[i].costGroupRange) < 75  )
   { ctx.fillStyle = "green";}
   else if (Number(HouseData.houses[i].costGroupRange) >= 75 && Number(HouseData.houses[i].costGroupRange) < 95  )
   { ctx.fillStyle = "brown";}
else if(Number(HouseData.houses[i].costGroupRange) >= 95 && Number(HouseData.houses[i].costGroupRange) <= 100  )
  {  ctx.fillStyle = "red";}
else{
    ctx.fillStyle = "black";
}
  ctx.beginPath();
        ctx.arc(HouseData.houses[i].xCoordinates*4,401-HouseData.houses[i].yCoordinates*4,2,0,8);
        ctx.stroke();
        ctx.fill();
}
};