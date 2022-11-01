import {
  Button, Image, ListGroup
} from 'react-bootstrap';
import classes from './SideBar.module.css';
import logo from '../../assets/boologo.png'
import { useNavigate } from "react-router";
import { Outlet, Link } from 'react-router-dom';
function SideBar() {
  const navigate = useNavigate();
  return (
    <div className={classes.sidebar}>
      <Image src={logo} className={classes.logo} />
      <ListGroup className={classes.list}>
        <ListGroup.Item action href="/">
          Tổng quan
        </ListGroup.Item>
        <ListGroup.Item action href="/product">
          Sản phẩm
        </ListGroup.Item>
        <ListGroup.Item action href="/category">
          Danh mục
        </ListGroup.Item>
      </ListGroup>
    </div>
  );
};

export default SideBar;
