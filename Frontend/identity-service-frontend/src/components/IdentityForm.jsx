import './IdentityForm.css';
import { useState } from 'react';
import RegisterForm from './RegisterForm';

export default function IdentityForm() {
    const [mode, setMode] = useState(false);

    return (
        <div className={mode ? "container active" : "container"} id="container">

            <RegisterForm setToggle={setMode} />

            <div className="form-container sign-in">

                <form>
                    <h1>Вход в аккаунт</h1>
                    <span>Введите ваш никнейм и пароль</span>
                    <input type="email" placeholder="Никнейм" />
                    <input type="password" placeholder="Пароль" />
                    <button>Вход</button>
                </form>

            </div>

            <div className="toggle-container">

                <div className="toggle">

                    <div className="toggle-panel toggle-left">
                        <h1>Уже зарегистрирован?</h1>
                        <p style={{marginBlock: "10px"}}>Заходи в аккаунт и начинай общение!</p>
                        <button className="hidden" id="login" onClick={() => setMode(!mode)}>Авторизация</button>
                    </div>

                    <div className="toggle-panel toggle-right">
                        <h1>Добро пожаловать!</h1>
                        <p style={{marginBlock: "10px"}}>У тебя нет аккаунта?<br />Регистрируйся и присоединяйся к чату!</p>
                        <button className="hidden" id="register" onClick={() => setMode(!mode)}>Регистрация</button>
                    </div>

                </div>

            </div>
            
        </div>
    );
}
