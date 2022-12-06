import React, { useState, useEffect } from 'react';
import './Login.css';


const Login = (props) => {
    const [enteredEmail, setEnteredEmail] = useState('');
    const [emailIsValid, setEmailIsValid] = useState();
    const [enteredPassword, setEnteredPassword] = useState('');
    const [passwordIsValid, setPasswordIsValid] = useState();
    const [formIsValid, setFormIsValid] = useState(false);
    const [userId, setUserId] = useState()

    useEffect(() => {
        const identifier = setTimeout(() => {
            setFormIsValid(
                enteredEmail.includes('@') && enteredPassword.trim().length > 6
            );
        }, 500)

        return () => { clearTimeout(identifier) }

    }, [enteredEmail, enteredPassword])

    const emailChangeHandler = (event) => {
        setEnteredEmail(event.target.value);
    };

    const passwordChangeHandler = (event) => {
        setEnteredPassword(event.target.value);
    };

    const validateEmailHandler = () => {
        setEmailIsValid(enteredEmail.includes('@'));
    };

    const validatePasswordHandler = () => {
        setPasswordIsValid(enteredPassword.trim().length > 6);
    };

    const submitHandler = (event) => {


        fetch('http://localhost:5267/api/User/getuser?email=' + enteredEmail + '&password=' + enteredPassword).then(function (response) {
            const data = response.json()
            if (!response.ok) {
                // make the promise be rejected if we didn't get a 2xx response
                console.log("PAS OK")
            } else {
                // got the desired response
                
                data.then(res => {
                    props.onLogin(enteredEmail, enteredPassword, res.id)
                    console.log("OK")
                })
                
                
            }
        }).catch(function (err) {
            console.log(err)
        });

        event.preventDefault()


    }

        

            
            
        

        
        
    //};

    return (
        
            <form onSubmit={submitHandler} className="bckgrd">
                <div
                    className="control"
                      
                >
                    <label htmlFor="email">E-Mail</label>
                    <input
                        type="email"
                        id="email"
                        value={enteredEmail}
                        onChange={emailChangeHandler}
                        onBlur={validateEmailHandler}
                    />
                </div>
                <div
                    className="control"
                >
                    <label htmlFor="password">Password</label>
                    <input
                        type="password"
                        id="password"
                        value={enteredPassword}
                        onChange={passwordChangeHandler}
                        onBlur={validatePasswordHandler}
                    />
                </div>
                <div className="actions">
                    <button type="submit" disabled={!formIsValid}>
                        Login
                    </button>
                </div>
            </form>
  
    );
};

export default Login;
