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
class UpdateCustomAttributeInAccountExample
{
    fun updateCustomAttributeInAccount()
    {
        ApiClient.apiKey["userApiKey"] = "USER_API_KEY"

        val customAttributeCreateUpdatePayload = CustomAttributeCreateUpdatePayload(
            attributeDisplayName = null,
            attributeDisplayType = null,
            attributeDescription = null,
            attributeKey = null,
            attributeModel = null,
            attributeValues = listOf (),
        )

        try
        {
            val response = CustomAttributesApi().updateCustomAttributeInAccount(
                accountId = null,
                id = null,
                _data = customAttributeCreateUpdatePayload,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling CustomAttributesApi#updateCustomAttributeInAccount")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling CustomAttributesApi#updateCustomAttributeInAccount")
            e.printStackTrace()
        }
    }
}
