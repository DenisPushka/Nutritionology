import {Component} from "react";
import {Nav} from "react-bootstrap";
import ".//Header.css";

// Шапка.
class Header extends Component {

    constructor(props) {
        super(props);

        // this.showLittleMenu = this.showLittleMenu.bind(this);
        // this.checkOpenMenu = this.checkOpenMenu.bind(this);
    }

    /**
     * Показывает меню при нажатии на "гамбургер".
     */
    // async showLittleMenu() {
    //     let openDropdown = document.getElementById('navId');
    //
    //     openDropdown.className = openDropdown.className !== 'show' ? 'show' : 'hide';
    //
    //     if (openDropdown.className === 'show') {
    //         window.setTimeout(function () {
    //             openDropdown.style.opacity = 1;
    //             openDropdown.style.transform = 'translateY(0px)';
    //         }, 0);
    //     } else if (openDropdown.className === 'hide') {
    //         openDropdown.style.opacity = 0.2;
    //         openDropdown.style.transform = 'translateY(-500px)';
    //     }
    // }

    /**
     * Проверка на скрытие "гамбургера".
     */
    // async checkOpenMenu() {
    //     window.onclick = (event: MouseEvent) => {
    //         if (!event.target.matches('.hamburger')) {
    //             let openDropdown = document.getElementById('navId');
    //             if (openDropdown.className === 'show') {
    //                 openDropdown.style.opacity = 0;
    //                 openDropdown.style.transform = 'translateY(-500px)';
    //                 openDropdown.className = 'hide';
    //             } else {
    //                 openDropdown.style.opacity = 0.2;
    //                 openDropdown.style.transform = 'translateY(-500px)';
    //             }
    //         }
    //     };
    // }


    render() {
        return (<>
            {/*<EventChangeWindow/>*/}

            <header className={"container_header"}>

                <div className={"name"}>
                    Nutritiology    
                </div>
                
                <div className={"logo"}>
                    Logo
                </div>

                {/*<div class="hamburger menu-toggle" onClick={this.showLittleMenu}>*/}
                {/*    <div class="line"></div>*/}
                {/*    <div class="line"></div>*/}
                {/*    <div class="line"></div>*/}
                {/*</div>*/}

                <div><Nav.Link href="/#">Главная</Nav.Link></div>
                <div><Nav.Link href="/About">О нас</Nav.Link></div>
                <div><Nav.Link href="/Command">Команда</Nav.Link></div>
                <div><Nav.Link href="/PK">Личный кабинет</Nav.Link></div>
                <div><Nav.Link href="/LogIn">Вход</Nav.Link></div>
                <div><Nav.Link href="/SignUp">Регистрация</Nav.Link></div>
                <div><Nav.Link href="/Menu">Мой рацион</Nav.Link></div>

            </header>
        </>);
    }
}

export default Header;