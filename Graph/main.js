function f(x){
    return Math.sin(x);
}

window.onload() : function(){
    var WIN = {
        LEFT: -10,
        BOTTOM: -10,
        WIDTH: 20,
        HEIGHT: 20
    };
    var graph = new Graph({WIN: WIN,
        callbacks:{
            wheel:wheel,
            mouseup:mouseup,
            mousedown:mousedown,
            mousemove:mousemove,
            mouseleave:mouseleave
    }});

    function renderFunction(f,color,width){
        var x = WIN.LEFT;
        var dx = WIN.WIDTH/100;
        while(x < WIN.WIDTH + WIN.LEFT){
            graph.line(x,f(x),x+dx,f(x+dx),color,width);
            x += dx;
        }
    
    }
    
    
    
    var ZOOM = 0.2;
    var canMove = false;
    function wheel(event){
        var delta = (event.wheelDelta > 0)?-ZOOM:ZOOM;
        WIN.WIDTH += delta;
        WIN.HEIGHT += delta;
        WIN.LEFT -= delta/2;
        WIN.BOTTOM -= delta/2;
    }
    function render(){
        graph.clear();
        renderOXY();
        renderFunction(f);
    }
    function mousedown(){
        canMove = true;
    }
    function mouseup(){
        canMove = false;
    }
    function mouseleave(){
        canMove = false;
    }
    function mousemove(event){
        if(canMove){
            WIN.LEFT -= graph.sx(event.movementX);
            WIN.BOTTOM -= graph.sy(event.movementY);
            render();
        }
    }
    
    renderFunction(f,'green');
}
