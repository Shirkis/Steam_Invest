import React from "react";
import Modal from "../common/Modal";
import {
  withStyles,
  Grid,
  Button,
  TextField,
  FormControl,
  InputLabel,
  Select,
  Icon,
  Typography,
  MenuItem,
  Paper
} from "@material-ui/core";
import { postItem, putItem} from "../../actions/item"
import { connect } from "react-redux";
import Loader from "../common/Loader";

let styles = theme => ({
    paper: {
        width: 400
    },
    select: {
        fontSize: 16,
        color: '#242421',
        '&:after': {
            backgroundColor: '#242421'
        }
    },
    selectIcon: {
        color: '#6D6D6D'
    },
    selectLine: {
        color: 'transparent'
    },
    formControl: {
        margin: theme.spacing.unit * 3
    },
    subtitle: {
        fontSize: 16,
        margin: "24px 0 6px 0",
        fontWeight: 600,
        fontFamily: '"BlissPro", "sans-serif"'
    },
    cancel: {
        opacity: 0.5,
        cursor: "pointer",
        marginTop: 24
    },
    addCircle: {
        cursor: "pointer",
        marginTop: 24
    }
})

class AddItemModal extends React.Component {
    state = {
        itemId: '',
        itemName: '',
        itemEditIsSet: false,
        fieldErrors:{
            itemName: false,
        }
    }

    componentWillReceiveProps(nextProps){
        if(nextProps.item) {
            this.setItemEdit(nextProps.item);
        }
    }

    setItemEdit = (item) => {
        this.setState({
            itemId: item.itemId,
            itemName: item.itemName,
            itemEditIsSet: true
        });
    }

    onFieldChange = (event) => {
        let { itemName, value } = event.target;
        let fieldErrors = this.state.fieldErrors;
        if(itemName == "name") {
            fieldErrors.itemName = false;
        }
        this.setState({ [itemName]: value, fieldErrors });
    }

    onSaveItem = () => {
        let { itemId, itemName, fieldErrors, itemEditIsSet } = this.state;
        let fieldsValid = true;

        if(itemName == '') {
            fieldErrors.itemName = true;
            fieldsValid = false;
        }
        this.setState({ fieldErrors });

        if(fieldsValid) {
            let item = {
                itemName: itemName
            }
            if(itemEditIsSet) this.props.putItem(itemId, item);
            else this.props.postItem(item);
            this.props.closeDialog();
            this.clearFields();
        }
    }

    onModalClose = () => {
        this.props.closeDialog();
        this.clearFields();
    }

    clearFields = () => {
        this.setState({
            itemId: '',
            itemName: '',
            itemEditIsSet: false,
            fieldErrors:{
                itemName: false
            }
        })
    }

    render(){
        const { dialogOpened, classes } = this.props;
        const { itemName, fieldErrors } = this.state;

        return(
        <Modal
            title={this.props.item ? "Редактировать предмет" : "Добавить предмет"}
            open={dialogOpened}
            classes={{ paper: classes.paper }}
            requestClose={this.onModalClose}
            primary={
              <Button onClick={() => { this.onSaveItem(); }} variant="raised" color="primary">
                Сохранить
              </Button>
            }
            secondary={<Button onClick={this.onModalClose}>Отмена</Button>}
        >
            <Grid container spacing={16}>
                <Grid item xs={12}>
                    <TextField fullWidth multiline required name="itemName"
                        value={itemName}
                        onChange={this.onFieldChange}
                        label="Название"
                        error={fieldErrors.itemName}
                    />
                </Grid>
            </Grid>
          </Modal>
        )
    }
}


export default connect(
    state => ({
      items: state.item.items,
      item: state.item.items
    }),
    dispatch => ({
      postItem: params => {
        dispatch(postItem(params));
      },
      putItem: (id, params) => {
        dispatch(putItem(id, params));
      }
    })
  )(withStyles(styles)(AddItemModal))