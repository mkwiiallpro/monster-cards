console.log("Sanity Test")
var isPainting = false;
var startX;
var startY;
var toolbar = document.getElementById("frm1");
var canvas = document.getElementById("cv");
var ctx = canvas.getContext("2d");
ctx.fillStyle = "white";
ctx.fillRect(0,0,255,255);
   canvas.addEventListener("mousestart", (e) => {
      isPainting = true;
      startX = e.clientX;
      startY = e.clientY;
   });

   canvas.addEventListener("mouseend", (e)=>{
      isPainting = false;
      ctx.stroke();
      ctx.beginPath();
   });

   canvas.addEventListener("mousemove",(e)=>{
      if(!isPainting){
         return;
      }
      ctx.lineWidth = 4;
      ctx.lineCap = "round";
      ctx.lineTo(e.clientX-canvas.offsetLeft, e.clientY);
      ctx.stroke();
   });

   toolbar.addEventListener("change", (e)=>{
      if(e.target.id === "stroke"){
         ctx.strokeStyle = e.target.value;
         console.log("color change");
      }
   });