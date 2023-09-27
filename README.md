# <p align="center"> Run-N-Gun</p>

<div align="Center">
    <img src = https://github.com/iFEL1x/iFEL1x/blob/main/Resources/Screenshots/Screen(Run-N-Gun).png width="600">
</div>

## Описание проекта

Данный проект, является выполненным тестовым заданием студии "FunLearnGames", которые предоставили ТЗ и спрайты для уровня.

Проект собран в Unity3D с использованием языка программирование C# и принципов ООП.

___
## Скачивание и установка
Для того что бы запустить проект на своем ПК

* [Скачайте](https://unity3d.com/ru/get-unity/download) и [установите](https://docs.unity3d.com/2018.2/Documentation/Manual/InstallingUnity.html) Unity3D версии «2021.3.12f1» с официального сайта.
* Скачайте проект по [ссылке](https://github.com/iFEL1x/) или с текущей странице "Code\Download ZIP".
    + Распакуйте архив на своем ПК.
* Запустите Unity3D
    + Рядом с кнопкой "Open" нажмите на стрелочку :arrow_down_small:, в открывшимся списке выберете "Add project from disk"
    + Выберете путь распаковки проекта, нажмите "Add Project"

___
## [Документация к проекту](https://cloud.mail.ru/public/ibNA/X8H5YDREg)
___
## В данном проекте применяется,
* Взаимодействие кода со Spine (работа с анимациями);
* Построение всего проекта максимально подводилось под ООП.


*Демонстрация кода:*

```C#
        private void EnableComponent<T>(T[] components) where T : MonoBehaviour, IActivatable
        {
            foreach (var component in components)
            {
                component.Activate();
            }
        }
```

```C#
        private void SetAnimationShoot(string animationName)
        {
            speed = 0f;

            var currentTrack = animation.AnimationState.SetAnimation(0, animationName, false);
            _currentNameAnimation = animationName;
            
            currentTrack.Complete += SetAnimationWalk;
        }
```

*Демонстрация финальной части игрового процесса:*

![Space-Invaders](https://github.com/iFEL1x/iFEL1x/blob/main/Resources/Image/Gif/mp4%20to%20GIF(Run-N-Gun).gif)
