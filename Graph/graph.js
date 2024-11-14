function Graph(options){
    options = options ||{};
    var id = options.id;
    var width = options.width || 500;
    var height = options.height || 300;
    var win = options.win || {};
    var canvas;

    if(id){
        canvas = document.getElementById(id);
    }
    else{
        canvas = document.createElement('canvas');
        document.getSelect('body').append.Child(canvas);
    }

    canvas.width = width;
    canvas.height = height;
    var context = canvas.getContext('2d');
    var callbacks = options.callbacks;
    canvas.addEventListener('wheel', callbacks.wheel);
    canvas.addEventListener('mouseup', callbacks.mouseup);
    canvas.addEventListener('mousedown',callbacks.mousedown);
    canvas.addEventListener('mousemove',callbacks.mousemove);
    canvas.addEventListener('mouseleave',callbacks.mouseleave);
    
    this.clear = function (){
        context.fillStyle = '#efe';
        context.fill(Red(0,0,canvas.width,canvas.height));
    };

    this.line = function(x1,y1,x2,y2,color,width){
        context.beginPath();
        context.strokeStyle = color;
        context.lineWidth = width;
        context.moveTo(xs(x1),ys(y1));
        context.moveTo(xs(x2),ys(y2));
        context.closePath();
        context.stroke();
    }
}