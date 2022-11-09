import { Button, Modal } from "react-bootstrap";
import { deleteProductAPI } from "../../../api/Product";
function DeleteProductModal({ status, onClose, data }) {
  function handleDelete() {
    console.log(data.productId);
    deleteProductAPI(data.productId)
      .then(() => {
        onClose();
          setTimeout(() => {
            alert("Xóa thành công!!!");
          }, 200);
      })
      .catch(() => {
        setTimeout(() => {
          alert("Xóa thất bại!!!");
        }, 200);
      });
  }
  return (
    <Modal show={status} backdrop="static">
      <Modal.Header>
        <Modal.Title>Xóa danh mục:</Modal.Title>
      </Modal.Header>
      <Modal.Body>Bạn có chắc chắn muốn xóa?</Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={onClose}>
          Đóng
        </Button>
        <Button
          type="submit"
          onClick={() => {
            handleDelete();
          }}
          variant="primary"
        >
          Xóa
        </Button>
      </Modal.Footer>
    </Modal>
  );
}
export default DeleteProductModal;
