import './css/site.css';
import 'bootstrap';

import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { AppContainer } from 'react-hot-loader';

import PhoneBook from "./PhoneBook";

function renderApp() {
    ReactDOM.render(
        <AppContainer>
            <PhoneBook />
        </AppContainer>,
        document.getElementById('react-app')
    );
}

renderApp();