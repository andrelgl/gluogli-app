import React from 'react'
import ReactDOM from 'react-dom'
import './styles/index.scss'

import Home from './views/home'
import Result from './views/result'

import {BrowserRouter, Switch, Route} from 'react-router-dom'
import * as serviceWorker from './serviceWorker'

ReactDOM.render(
    <BrowserRouter>
        <Switch>
            <Route path="/" exact={true} component={Home}/>
            <Route path="/result" component={Result}/>
        </Switch>
    </BrowserRouter>, 
    document.getElementById('root')
);


// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
serviceWorker.unregister();
