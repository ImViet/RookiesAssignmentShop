import {
  Button, Image, ListGroup
} from 'react-bootstrap';
// import Button from 'react-bootstrap/Button';
// import Img from 'react-bootstrap/Image';
import classes from './SideBar.module.css';
import logo from '../../assets/boologo.png'
function SideBar() {
  return (
    <div className={classes.sidebar}>
      <Image src={logo} className={classes.logo} />
      <ListGroup className={classes.list} defaultActiveKey="#link1">
        <ListGroup.Item action href="#overview">
          Tổng quan
        </ListGroup.Item>
        <ListGroup.Item action href="#product">
          Sản phẩm
        </ListGroup.Item>
        <ListGroup.Item action href="#category">
          Danh mục
        </ListGroup.Item>
      </ListGroup>
    </div>
  );
};

export default SideBar;
