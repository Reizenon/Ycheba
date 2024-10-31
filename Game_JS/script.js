var current = 'start';

var ROOMS = {
    start: {
        title: "Комната в общаге",
        description: "Надо меньше пить!",
        img: "/img/roucher.jpeg",
        exits: ["hall"],
        foundMoney: false,
        findMoney: function ()
        {
            if (!this.foundMoney)
            {
                var moneyFound = Math.floor(Math.random() * 21);
                user.money += moneyFound;
                displayMessage('Вы нашли ' + (moneyFound) + ' теперь у вас ' + (user.money) + ' монет');
                loadUserStat();
                this.foundMoney = true;
            }
            else displayMessage('Вы уже взяли деньги');
        },
    },
    hall: {
        title: "Холл",
        description: "Вокруг никого",
        img: "/img/hall.jpeg",
        exits: ["start", "toulet", "cafeteria"],

    },
    toulet: {
        title: "Туалет",
        description: "Ну и жуть",
        img: "/img/toulet.jpeg",
        exits: ["hall"],

    },
    cafeteria: {
        title: "Столовая",
        description: "Можно и перекусить",
        img: "/img/cafeteria.jpg",
        exits: ["hall"],
        eat: function (price)
        {
            if (user.money < price)
            {
                displayMessage("Недостаточно денег для покупки еды.");
                return;
            }
            user.money -= price;
            user.hp += price * 2;
            displayMessage('Ваше здоровье увеличено на ' + (price * 2) + ' текущее здоровье ' + (user.hp));
            loadUserStat();
        },
    },
};

function loadUserStat()
{
    document.getElementById('userName').innerText = 'Имя: ' + user.name;
    document.getElementById('userHp').innerText = 'Здоровье: ' + user.hp;
    document.getElementById('userMoney').innerText = 'Деньги: ' + user.money;
}

var user = {
    name: 'Данил',
    hp: 100,
    money: 0,
}

function displayMessage(message)
{
    var messageElement = document.getElementById('message');
    messageElement.innerHTML = message;
}

function render()
{
    var room = ROOMS[current];
    document.getElementById('title').innerHTML = room.title;
    document.getElementById('description').innerHTML = room.description;
    document.getElementById('roomImage').src = room.img;
    var exits = document.getElementById('exits');
    exits.innerHTML = '';
    loadUserStat();
    for (var i = 0; i < room.exits.length; i++)
    {
        (function (i)
        {
            var button = document.createElement('button');
            button.innerHTML = ROOMS[room.exits[i]].title;
            exits.appendChild(button);
            button.addEventListener('click', function ()
            {
                hitPerStep();
                current = room.exits[i];
                displayMessage('');
                render();
            });
        })(i);
    }

    if (current === 'start' && !room.moneyFound)
    {
        var findMoneyButton = document.createElement('button');
        findMoneyButton.innerHTML = "Найти деньги";
        exits.appendChild(findMoneyButton);
        findMoneyButton.addEventListener('click', function ()
        {
            ROOMS.start.findMoney();
        });
    }

    if (current === 'cafeteria')
    {
        var eatButton = document.createElement('button');
        eatButton.innerHTML = "Поесть (цена: 10)";
        exits.appendChild(eatButton);
        eatButton.addEventListener('click', function ()
        {
            ROOMS.cafeteria.eat(10);
        });
    }
}

function hitPerStep()
{
    user.hp -= 2;
    if (user.hp <= 0)
    {
        displayMessage("Вы погибли! Игра окончена.");
    }
}

function resetGame()
{
    user.hp = 100;
    user.money = 0;
    current = 'start';
    ROOMS.start.foundMoney = false;
    render();
}

window.onload = function ()
{
    render();
}
