import './IdentityForm.css';
import { useState } from 'react';
import axios from 'axios'

export default function IdentityForm() {
    const [mode, setMode] = useState(false);

    const [nickname, setNickname] = useState("");
    const [nicknameIsValid, setNicknameIsValid] = useState(true);

    const [password, setPassword] = useState("");
    const [passwordIsValid, setPasswordIsValid] = useState(true);

    const [secondPassword, setSecondPassword] = useState("");
    const [secondPasswordIsValid, setSecondPasswordIsValid] = useState(true);

    function OnChangeNickname(e) {
        let value = e.target.value;
        setNickname(value);
        
        if (value.length == 0 || (value.length >= 4 && value.length <= 20)) setNicknameIsValid(true);
        else setNicknameIsValid(false);
    }

    function OnChangePassword(e, setPassword, setIsValid) {
        let value = e.target.value;
        setPassword(e.target.value);
        
        if (value.length == 0 || (value.length >= 8 && value.length <= 30)) setIsValid(true);
        else setIsValid(false);
    }

    async function RegisterUser(e) {
        e.preventDefault();
        
        if (nickname.length < 4 || password.length < 8 || secondPassword.length < 8) return;
        if (!nicknameIsValid || !passwordIsValid || !secondPasswordIsValid) return;
        if (password != secondPassword) return;

        try {
            const response = await axios.post('http://localhost:5255/api/users/register', {Nickname: nickname, Password: password});
            console.log(response.data);
        } catch (error) {
            console.error(error.response.data);
        }
    }
    

    return (
        <div className={mode ? "container active" : "container"} id="container">

            <div className="form-container sign-up">

                <form>
                    <h1>Регистрация</h1>
                    <span>Придумай себе уникальный никнейм и пароль</span>
                    <input 
                        className={nicknameIsValid ? "input-valid" : "input-not-valid"}
                        type="text" placeholder="Никнейм"
                        onChange={OnChangeNickname}
                    />
                    <input
                        className={passwordIsValid ? "input-valid" : "input-not-valid"}
                        type="password"
                        placeholder="Пароль"
                        onChange={(e) => OnChangePassword(e, setPassword, setPasswordIsValid)}
                    />
                    <input
                        className={secondPasswordIsValid ? "input-valid" : "input-not-valid"}
                        type="password"
                        placeholder="Подтвердите пароль"
                        onChange={(e) => OnChangePassword(e, setSecondPassword, setSecondPasswordIsValid)}
                    />
                    <button type="submit" onClick={RegisterUser}>Подтвердить</button>
                </form>

            </div>

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
                        <p>Переходи к авторизации!</p>
                        <button className="hidden" id="login" onClick={() => setMode(!mode)}>Авторизация</button>
                    </div>

                    <div className="toggle-panel toggle-right">
                        <h1>Добро пожаловать!</h1>
                        <p>У тебя нет аккаунта?<br />Регистрируйся и присоединяйся к чату!</p>
                        <button className="hidden" id="register" onClick={() => setMode(!mode)}>Регистрация</button>
                    </div>

                </div>

            </div>
            
        </div>
    );
}
