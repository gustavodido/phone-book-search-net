import React from 'react';

import ResponsiveContainer from '../containers/ResponsiveContainer.js'
import Row from '../containers/Row.js'
import Column from '../containers/Column.js'
import FormGroup from '../containers/groups/FormGroup.js'
import Panel from '../containers/Panel.js'
import ModalDialogFooter from '../containers/modal/ModalDialogFooter.js'
import ModalDialogCloseButton from '../containers/modal/ModalDialogCloseButton.js'

import Button from '../elements/Button.js'
import TextInput from '../elements/TextInput.js'

import PhoneField from './PhoneField.js'

class ContactManagement extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            uuid: "",
            firstName: "",
            lastName: "",
            fullName: "",
            homePhone: "",
            workPhone: "",
            mobilePhone: "",
            firstNameError: false,
            lastNameError: false
        };

        this.baseState = Object.assign({}, this.state);
    }

    componentWillReceiveProps(nextProps) {
        this.setState(this.baseState);
        this.setState(nextProps.contact);
    }

    handleOnClick(e) {
        if (this.state.firstName == "" || this.state.lastName == "") {
            this.setState({ firstNameError: this.state.firstName == ""});
            this.setState({ lastNameError: this.state.lastName == ""});
        }
        else {
            this.props.onSaveContactClick(this.state);
        }
    }

    render() {
        return (
            <ResponsiveContainer>
                <Row>
                    <Column size="6">
                        <FormGroup customClasses={this.state.firstNameError ? "has-error" : ""}>
                            <label for="firstName">First name:</label>
                            <TextInput id="firstName"
                                       placeholder="ex: Gustavo"
                                       value={ this.state.firstName }
                                       onChange={ (text) => this.setState({ firstName: text } ) }
                                       maxLength="50"
                            />
                            {
                                this.state.firstNameError &&
                                    <span id="helpBlock2" className="help-block text-danger">You must provide a first name.</span>
                            }
                        </FormGroup>
                    </Column>
                    <Column size="6">
                        <FormGroup customClasses={this.state.lastNameError ? "has-error" : ""}>
                            <label for="lastName">Last name:</label>
                            <TextInput id="lastName"
                                       placeholder="ex: Domenico"
                                       value={ this.state.lastName }
                                       onChange={ (text) => this.setState({ lastName: text } ) }
                                       maxLength="50"
                            />
                            {
                                this.state.lastNameError &&
                                <span id="helpBlock2" className="help-block text-danger">You must provide a last name.</span>
                            }
                        </FormGroup>
                    </Column>
                </Row>
                <Row>
                    <Column>
                        <Panel title="Phones">
                            <ResponsiveContainer>
                                <Column size="2"></Column>
                                <Column size="8">
                                    <PhoneField label="Home"
                                                value={ this.state.homePhone }
                                                onChange={ (text) => this.setState({ homePhone: text }) }/>
                                    <PhoneField label="Work"
                                                value={ this.state.workPhone }
                                                onChange={ (text) => this.setState({ workPhone: text } ) }/>
                                    <PhoneField label="Mobile"
                                                value={ this.state.mobilePhone }
                                                onChange={ (text) => this.setState({ mobilePhone: text } ) }/>
                                </Column>
                                <Column size="2"></Column>
                            </ResponsiveContainer>
                        </Panel>
                    </Column>
                </Row>
                <ModalDialogFooter>
                    <ModalDialogCloseButton />
                    <Button text="Save changes"
                            customClasses="btn-primary"
                            onClick={ this.handleOnClick.bind(this) }
                    />
                </ModalDialogFooter>
            </ResponsiveContainer>
        );
    };
}

export default ContactManagement;
