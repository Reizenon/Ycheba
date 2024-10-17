var ROOMS = {
    start: {
        title: "Комната в общаге",
        description: "Надо меньше пить!",
        img: "/img/roucher.jpg",
        exits: ["hall"]
    },
    hall: { 
        title: "Холл",
        description: "Вокруг никого",
        img: "/img/hall.jpg",
        exits: ["start"],
        exits: ["toulet"]
    },
    toulet: { 
        title: "Туалет",
        description: "Ну и жуть",
        img: "/img/toulet.jpg",
        exits: ["hall"]
    },
};
function render()
{
    var room = ROOMS[current];
    document.getElementById('title').innerHTML = room.title;
    document.getElementById('description').innerHTML = room.description;
    document.getElementById('roomImage').src = room.img;
    var exits = document.getElementById('exits');
    exits.innerHTML = '';
    for (var i = 0; i < room.exits.length; i++)
    {
        var button = document.createElement('button');
        button.innerHTML = ROOMS[room.exits[i]].title;
        exits.appendChild(button);
        button.addEventListener('click', function ()
        {
            current = room.exits[i];
            render();
        });
    }
}
window.onload = function ()
{
    render();
}