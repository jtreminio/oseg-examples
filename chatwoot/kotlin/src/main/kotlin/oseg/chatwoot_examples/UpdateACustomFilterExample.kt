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
class UpdateACustomFilterExample
{
    fun updateACustomFilter()
    {
        ApiClient.apiKey["userApiKey"] = "USER_API_KEY"
        // ApiClient.apiKey["agentBotApiKey"] = "AGENT_BOT_API_KEY"
        // ApiClient.apiKey["platformAppApiKey"] = "PLATFORM_APP_API_KEY"

        val customFilterCreateUpdatePayload = CustomFilterCreateUpdatePayload(
            name = null,
            type = null,
        )

        try
        {
            val response = CustomFiltersApi().updateACustomFilter(
                accountId = null,
                customFilterId = null,
                _data = customFilterCreateUpdatePayload,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling CustomFiltersApi#updateACustomFilter")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling CustomFiltersApi#updateACustomFilter")
            e.printStackTrace()
        }
    }
}
