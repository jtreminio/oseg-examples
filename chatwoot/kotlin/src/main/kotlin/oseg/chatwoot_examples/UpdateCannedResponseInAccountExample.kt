package oseg.chatwoot_examples

import com.chatwoot.client.infrastructure.*
import com.chatwoot.client.apis.*
import com.chatwoot.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class UpdateCannedResponseInAccountExample
{
    fun updateCannedResponseInAccount()
    {
        ApiClient.apiKey["userApiKey"] = "USER_API_KEY"

        val cannedResponseCreateUpdatePayload = CannedResponseCreateUpdatePayload(
            content = null,
            shortCode = null,
        )

        try
        {
            val response = CannedResponseApi().updateCannedResponseInAccount(
                accountId = null,
                id = null,
                _data = cannedResponseCreateUpdatePayload,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling CannedResponseApi#updateCannedResponseInAccount")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling CannedResponseApi#updateCannedResponseInAccount")
            e.printStackTrace()
        }
    }
}
