import {toast} from "react-toastify"

export const notificacao = (msg: string) => toast.success(msg);
export const erro = (msg: string) => toast.error(msg);

export const toastConfirmarExclusao = (aoConfirmar: () => void) => {
    toast(
        ({ closeToast }) => (
            <div>
                <p>Deseja realmente excluir?</p>

                <div style={{ display: "flex", gap: "8px", marginTop: "10px" }}>
                    <button style={{ border: "none", padding: "8px", borderRadius: "5px", backgroundColor: "#451201", cursor: "pointer", color: "#FFA300"}}
                        onClick={() => {
                            aoConfirmar();
                            closeToast();
                        }}
                    >
                        Sim
                    </button>

                    <button onClick={closeToast} style={{ border: "none", padding: "8px", borderRadius: "5px", backgroundColor: "#451201", cursor: "pointer", color: "#FFA300"}}>
                        Cancelar
                    </button>
                </div>
            </div>
        ),
        {
            autoClose: false,
            closeOnClick: false,
            draggable: false,
        }
);
};