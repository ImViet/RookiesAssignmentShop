import { useEffect, useState } from "react";
import { Button, Modal } from "react-bootstrap";
import {deleteCategoryAPI, getCategoryAPI} from "../../../api/Category";
function DeleteCategoryModal({status, onClose, data}) {
    function handleDelete(){
        console.log(data.categoryId)
        deleteCategoryAPI(data.categoryId);
    }
    return (
        <Modal
        show={status}
        backdrop="static"
      >
        <Modal.Header closeButton>
          <Modal.Title>Xóa danh mục:</Modal.Title>
        </Modal.Header>
        <Modal.Body>
         Bạn có chắc chắn muốn xóa? 
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={onClose}>
            Đóng
          </Button>
          <Button type="submit" onClick={handleDelete} variant="primary">Xóa</Button>
        </Modal.Footer>
      </Modal>
      
    );
  }
  export default DeleteCategoryModal;