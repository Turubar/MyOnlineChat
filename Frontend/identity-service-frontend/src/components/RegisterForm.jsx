import { useState } from 'react';
import axios from 'axios';

export default function RegisterForm({setToggle}) {

    const [nickname, setNickname] = useState("");
    const [nicknameIsValid, setNicknameIsValid] = useState(true);

    const [password, setPassword] = useState("");
    const [passwordIsValid, setPasswordIsValid] = useState(true);

    const [secondPassword, setSecondPassword] = useState("");
    const [secondPasswordIsValid, setSecondPasswordIsValid] = useState(true);

    const defaultMessage = "Придумайте никнейм и пароль";
    const [stateMessage, setStateMessage] = useState(defaultMessage);

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

        if (!ValidateData()) return;

        try {
            const response = await axios.post('http://localhost:5255/api/users/register', {Nickname: nickname, Password: password});
            
            console.log(response);

           /*  setTimeout(() => {
                document.getElementById("nicknameRegister").value = "";
                document.getElementById("passwordRegister").value = "";
                document.getElementById("secondPasswordRegister").value = "";

                setToggle(false);
            }, 3000) */
        } 
        catch (error) {
            console.log(error);
        }
    }

    function ValidateData() {
        if (nickname.length == 0 || password.length == 0 || secondPassword.length == 0) {
            ShowMessage("Не все поля заполнены!", "red");
            return false;
        }
        
        if (!nicknameIsValid || !passwordIsValid || !secondPasswordIsValid) {
            ShowMessage("Некорректный ввод данных!", "red");
            return false;
        }

        if (password != secondPassword) {
            ShowMessage("Пароли не совпадают!", "red");
            return false;
        }

        return true;
    }

    function ShowMessage(message, color) {
        const span = document.getElementById("stateMessage");
        const btn = document.getElementById("registerBtn");

        setStateMessage(message);

        btn.disabled = "disabled";
        span.style.color = color;

        setTimeout(() => {
            setStateMessage(defaultMessage);

            btn.disabled = "";
            span.style.color = "black";
        }, 3000)
    }

    return (
        <div className="form-container sign-up">

                <form>
                    <h1>Регистрация</h1>
                    <span id='stateMessage'>{stateMessage}</span>
                    <input
                        id='nicknameRegister'
                        className={nicknameIsValid ? "input-valid" : "input-not-valid"}
                        type="text" placeholder="Никнейм"
                        onChange={OnChangeNickname}
                    />
                    <input
                        id='passwordRegister'
                        className={passwordIsValid ? "input-valid" : "input-not-valid"}
                        type="password"
                        placeholder="Пароль"
                        onChange={(e) => OnChangePassword(e, setPassword, setPasswordIsValid)}
                    />
                    <input
                        id="secondPasswordRegister"
                        className={secondPasswordIsValid ? "input-valid" : "input-not-valid"}
                        type="password"
                        placeholder="Подтвердите пароль"
                        onChange={(e) => OnChangePassword(e, setSecondPassword, setSecondPasswordIsValid)}
                    />
                    <button id='registerBtn' type="submit" onClick={RegisterUser}>Подтвердить</button>
                </form>

            </div>
    );
}