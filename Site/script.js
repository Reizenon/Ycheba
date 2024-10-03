let score = 0;

document.getElementById('shootButton').addEventListener('click', function ()
{
    const x = parseInt(document.getElementById('xCoord').value);
    const y = parseInt(document.getElementById('yCoord').value);

    // Определяем радиус мишени
    const targetRadius = 10; // радиус в пикселях

    // Проверяем, попал ли выстрел в мишень

    const circle = Math.sqrt((x, 2) + (y, 2));

    if ((x <= 10 && x >= 0) && (y <= 10 && y >= 0))
    {
        if (circle <= targetRadius)
        {
            score += 2;
            alert('Попадание!');
            markHit(x, y);
        }
        else
        {
            score += 1;
            alert('Попадание!');
            markHit(x, y);
        }
    }

    else
    {
        alert('Промах!');
    }

    document.getElementById('score').innerText = 'Очки: ' + score;

    // Очищаем поля ввода
    document.getElementById('xCoord').value = '';
    document.getElementById('yCoord').value = '';
});

function markHit(x, y)
{
    const target = document.getElementById('target');

    // Создаем новый элемент для попадания
    const hitMarker = document.createElement('div');
    hitMarker.className = 'hit';

    // Устанавливаем позицию метки
    hitMarker.style.left = (x * 50) + 'px';  // Смещение для центрирования
    hitMarker.style.top = (y * 50) + 'px';  // Смещение для центрирования

    target.appendChild(hitMarker);
}
